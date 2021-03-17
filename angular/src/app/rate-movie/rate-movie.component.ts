import {
  Component,
  Injector,
  OnInit,
  EventEmitter,
  Output
} from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { forEach as _forEach, map as _map } from 'lodash-es';
import { AppComponentBase } from '@shared/app-component-base';
import {
  MovieServiceProxy,
  CreateMovieInput, 
  RatingServiceProxy,
  CreateRatingInput,
  MovieListDto,
  
} from '@shared/service-proxies/service-proxies';
import { AbpValidationError } from '@shared/components/validation/abp-validation.api';
import * as moment from 'moment';

@Component({
  selector: 'app-rate-movie',
  templateUrl: './rate-movie.component.html',
  styleUrls: ['./rate-movie.component.css']
})
export class RateMovieComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  rate = new CreateRatingInput();
  id: number;
  movieName : string;
  
 
  
  checkedRolesMap: { [key: string]: boolean } = {};
  defaultRoleCheckedStatus = false;
  

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _rateService: RatingServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    console.log(this.id);
    console.log(this.movieName);
  }
  
  save(): void {
    this.saving = true; 
    //this.movie.releaseDate = moment(this.movie.releaseDate);
    //JSON.stringify(this.movie)
    this.rate.movieId = this.id;
    this._rateService
      .createRating(this.rate)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      });
  }
}

