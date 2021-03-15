import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto
} from 'shared/paged-listing-component-base';
import {
  AuditListDto,
  AuditListDtoPagedResultDto,
  MovieServiceProxy,
  UserDto,
  UserDtoPagedResultDto
} from '@shared/service-proxies/service-proxies';
// import { CreateUserDialogComponent } from './create-user/create-user-dialog.component';
// import { EditUserDialogComponent } from './edit-user/edit-user-dialog.component';
// import { ResetPasswordDialogComponent } from './reset-password/reset-password.component';

class PagedAuditlogsRequestDto extends PagedRequestDto {
  apiName: string;
  isActive: boolean | null;
}

@Component({
  selector: 'app-auditlogdetails',
  templateUrl: './auditlogdetails.component.html',
  styleUrls: ['./auditlogdetails.component.css']
})
export class AuditlogdetailsComponent extends PagedListingComponentBase<UserDto> {
  audits: AuditListDto[] = [];
  apiName = '';
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
    this.getAllAudits("",0,10);
  }

  getAllAudits(apiName: string, skipCount: number, maxResultCount: number){
    this._movieService.getAllAuditLogs(apiName, skipCount, maxResultCount)
    .pipe(
     finalize(() => {
       console.log("Error")
        //finishedCallback();
     })
   )
    .subscribe( data => { 
      console.log(data)
      this.audits=data.items;
      this.totalItems=data.totalCount;
 
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

    this._movieService
      .getAllAuditLogs(
        request.apiName,
        //request.isActive,
        request.skipCount,
        request.maxResultCount
      )
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: AuditListDtoPagedResultDto) => {
        this.audits = result.items;
        this.showPaging(result, pageNumber);
      });
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

