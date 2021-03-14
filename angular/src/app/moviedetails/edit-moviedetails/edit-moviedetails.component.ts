import {
  Component,
  Injector,
  OnInit,
  EventEmitter,
  Output
} from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { forEach as _forEach, includes as _includes, map as _map } from 'lodash-es';
import { AppComponentBase } from '@shared/app-component-base';
import {
  MovieServiceProxy,
  UserDto,
  RoleDto,
  UpdateMovieInput
} from '@shared/service-proxies/service-proxies';
import * as moment from 'moment';

@Component({
  selector: 'app-edit-moviedetails',
  templateUrl: './edit-moviedetails.component.html',
  styleUrls: ['./edit-moviedetails.component.css']
})
export class EditMoviedetailsComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  movie = new UpdateMovieInput();
  moviedetails = new UpdateMovieInput();
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _movieService: MovieServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }


  ngOnInit(): void {
    // console.log(moment(this.moviedetails.releaseDate));
    // console.log(this.moviedetails.releaseDate);
    // console.log(this.moviedetails.releaseDate.toDate()); 
    // console.log(this.moviedetails.releaseDate.format('YYYY-MM-DD')); 
    this.moviedetails.releaseDate = this.moviedetails.releaseDate.format('YYYY-MM-DD');
    this.movie = this.moviedetails
   // console.log(this.movie);
    // this._userService.get(this.id).subscribe((result) => {
    //   this.user = result;

    //   this._userService.getRoles().subscribe((result2) => {
    //     this.roles = result2.items; 
    //     this.setInitialRolesStatus();
    //   });
    // });
  }

  

  save(): void {
    this.saving = true;
    this.movie.releaseDate = moment(this.movie.releaseDate);
    JSON.stringify(this.movie)
    this._movieService
      .updateMovie(this.movie)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('UpdatedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      });
  }
}
