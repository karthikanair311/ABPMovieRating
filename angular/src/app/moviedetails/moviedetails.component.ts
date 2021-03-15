import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto
} from 'shared/paged-listing-component-base';
import {
 
  MovieServiceProxy,
  MovieListDto,
  UpdateMovieInput,
  //MovieListDtoListResultDto,
  MovieListDtoPagedResultDto
 
} from '@shared/service-proxies/service-proxies';
import { CreateMoviedetailsComponent } from './create-moviedetails/create-moviedetails.component';
import { EditMoviedetailsComponent } from './edit-moviedetails/edit-moviedetails.component';
import { ViewMoviedetailsComponent } from './view-moviedetails/view-moviedetails.component';
//import { CreaterateMoviedetailsComponent } from './createrate-moviedetails/createrate-moviedetails.component';


class PagedMovieRequestDto extends PagedRequestDto {
  genre: string;
  isActive: boolean | null;
}

@Component({
  selector: 'app-moviedetails',
  templateUrl: './moviedetails.component.html',
  styleUrls: ['./moviedetails.component.css']
})
export class MoviedetailsComponent  extends PagedListingComponentBase<MovieListDto> {
  movies: MovieListDto[] = [];
  genre = "";
  isActive: boolean | null;
  advancedFiltersVisible = false;

  constructor(
    injector: Injector,
    private _movieService: MovieServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.getAllMovies("",0,10);
  }

  getAllMovies(genre: string, skipCount: number, maxResultCount: number){
    this._movieService.getMovieItems(genre, skipCount, maxResultCount)
    .pipe(
     finalize(() => {
       console.log("Error")
        //finishedCallback();
     })
   )
    .subscribe( data => { 
      console.log(data)
      this.movies=data.items;
      this.totalItems=data.totalCount;
 
    });


  }
     
  createMovie(): void {
    this.showCreateOrEditMovie();
  }

  editMovie(movie: UpdateMovieInput): void {
   this.showEditMovie(movie);
  }

  // viewMovie(movie: MovieListDto): void {
  //   this.getAllMovies(movie.genre, movie.title, movie.releaseDate)
  // }

  // createRating(): void {
  //   this.showCreateRateMovie();
  // }
  

  clearFilters(): void {
    this.genre = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }

  protected list(
    request: PagedMovieRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.genre = this.genre;
    // request.isActive = this.isActive;
     request.skipCount,
     request.maxResultCount

    console.log(this.genre);
  //   this._movieService.getAll(request.genre, request.skipCount, request.maxResultCount )
  //   .pipe(
  //    finalize(() => {
  //      console.log("Error")
  //       finishedCallback();
  //    })
  //  )
  //   .subscribe( data => { 
  //     console.log(data)
  //     this.movies=data.items;
 
  //   });

  console.log("a : " +request.skipCount);
  console.log("aa : " +request.maxResultCount);
    console.log("aaa : " +request.genre);


    this._movieService
      .getMovieItems(
        request.genre,
        //request.isActive,
        request.skipCount,
        request.maxResultCount
      )
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: MovieListDtoPagedResultDto) => {
        this.movies = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  protected delete(movie: MovieListDto): void {
    abp.message.confirm(
      this.l('MovieDeleteWarningMessage', movie.title),
      undefined,
      (result: boolean) => {
        if (result) {
          this._movieService.deleteMovie(movie.id).subscribe(() => {
            abp.notify.success(this.l('SuccessfullyDeleted'));
            this.refresh();
          });
        }
      }
    );
  }

  // private showCreateRateMovie (id?: number): void {
  //   let CreateRateMovie: BsModalRef;
  //   if (!id) {
  //     CreateRateMovie = this._modalService.show(
  //       CreaterateMoviedetailsComponent,
  //       {
  //         class: 'modal-lg',
  //       }
  //     );
  //   }

  // }



  private showCreateOrEditMovie (id?: number): void {
    let createOrEditMovie: BsModalRef;
    if (!id) {
      createOrEditMovie = this._modalService.show(
        CreateMoviedetailsComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditMovie = this._modalService.show(
        EditMoviedetailsComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditMovie.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  private showEditMovie (movie : UpdateMovieInput): void {
    let createOrEditMovie: BsModalRef;
    if (!movie) {
      createOrEditMovie = this._modalService.show(
        CreateMoviedetailsComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      
      createOrEditMovie = this._modalService.show(
        EditMoviedetailsComponent,
        {
          class: 'modal-lg',
          initialState: {
           // id: id,
           moviedetails : movie
           
          },
        }
        
      );
      
    }

    createOrEditMovie.content.onSave.subscribe(() => {
      this.refresh();
    });

   

  }
}
