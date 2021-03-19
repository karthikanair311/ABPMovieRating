import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import{ ActivatedRoute } from '@angular/router';
import {
  PagedListingComponentBase,
  PagedRequestDto
} from 'shared/paged-listing-component-base';
import {
 
  FullMovieDetailsListDto,
  MovieServiceProxy,
  UserDto
  
} from '@shared/service-proxies/service-proxies';
// import { CreateUserDialogComponent } from './create-user/create-user-dialog.component';
// import { EditUserDialogComponent } from './edit-user/edit-user-dialog.component';
// import { ResetPasswordDialogComponent } from './reset-password/reset-password.component';

class PagedAuditlogsRequestDto extends PagedRequestDto {
  apiName: string;
  isActive: boolean | null;
}

@Component({
  selector: 'app-all-moviedetails',
  templateUrl: './all-moviedetails.component.html',
  styleUrls: ['./all-moviedetails.component.css']
})
export class AllMoviedetailsComponent extends PagedListingComponentBase<UserDto> {
  alldets: FullMovieDetailsListDto;
  // alldetjson : any;
  // alldetsstring : any;
  apiName = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;
  id: number = 0;

  constructor(
    injector: Injector,
    private _movieService: MovieServiceProxy,
    private _modalService: BsModalService,
    private _activatedRoute: ActivatedRoute
  ) {
    super(injector);
  }

  ngOnInit(): void {
    
    this.id = this._activatedRoute.snapshot.queryParams['MovieId'];
    console.log(this.id);
    this.getFullMovieDetails(this.id);
  }

  getFullMovieDetails(id: number){
    this._movieService.getMovieDetails(id)
    .pipe(
     finalize(() => {
       console.log("Error")
        //finishedCallback();
     })
   )
    .subscribe( (data) => { 
      console.log("------")
      console.log(data)
      console.log(data.title)
      this.alldets = data;
      console.log(this.alldets);
      //this.alldets.movieRatings

      
      // this.alldetsstring=JSON.stringify(data); 
      // console.log(this.alldetsstring);
      // this.alldetjson = JSON.parse(this.alldetsstring);
      // console.log(this.alldetjson); 
      // console.log(this.alldetjson.castList[0].actorName);
      //console.log(this.alldets)
      //this.alldets=data.title;
     // this.totalItems=data.totalCount;
     
 
    });
  }

  // createUser(): void {
  //   this.showCreateOrEditUserDialog();
  // }

  // editUser(user: UserDto): void {
  //   this.showCreateOrEditUserDialog(user.id);
  // }

  // public resetPassword(user: UserDto): void {
  //   this.showResetPasswordUserDialog(user.id);
  // }

  clearFilters(): void {
    this.apiName = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }

  protected list(
    request: PagedAuditlogsRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.apiName = this.apiName;
    request.isActive = this.isActive;

    this._movieService.getMovieDetails(null)
    .pipe(
     finalize(() => {
       console.log("Error")
        //finishedCallback();
     })
   )
    .subscribe( data => { 
      console.log(data)
      //this.alldets=data.items;
     // this.totalItems=data.totalCount;
 
    });

    // this._movieService
    //   .getAllAuditLogs(
    //     request.apiName,
    //     //request.isActive,
    //     request.skipCount,
    //     request.maxResultCount
    //   )
    //   .pipe(
    //     finalize(() => {
    //       finishedCallback();
    //     })
    //   )
    //   .subscribe((result: AuditListDtoPagedResultDto) => {
    //     this.audits = result.items;
    //     this.showPaging(result, pageNumber);
    //   });
  }

  protected delete(user: UserDto): void {
    // abp.message.confirm(
    //   this.l('UserDeleteWarningMessage', user.fullName),
    //   undefined,
    //   (result: boolean) => {
    //     if (result) {
    //       this._userService.delete(user.id).subscribe(() => {
    //         abp.notify.success(this.l('SuccessfullyDeleted'));
    //         this.refresh();
    //       });
    //     }
    //   }
    // );
  }

  
}


