import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto
} from 'shared/paged-listing-component-base';
import {
  ActorListDto,
  ActorServiceProxy,
  UserDto,
  UserDtoPagedResultDto
} from '@shared/service-proxies/service-proxies';
import { CreateActorComponent } from './create-actor/create-actor.component';
import { EditActorComponent } from './edit-actor/edit-actor.component';
import { PermissionCheckerService } from 'abp-ng2-module';


class PagedActorRequestDto extends PagedRequestDto {
  actorGender: string;
  isActive: boolean | null;
}

@Component({
  selector: 'app-actordetails',
  templateUrl: './actordetails.component.html',
  styleUrls: ['./actordetails.component.css']
})
export class ActordetailsComponent extends PagedListingComponentBase<ActorListDto> {
  actors: ActorListDto[] = [];
  actorGender = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;
  isAdmin = false;

  constructor(
    private _permissionChecker: PermissionCheckerService,
    injector: Injector,
    private _actorService: ActorServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  
  ngOnInit(): void {
    this.getAllActors("");
   this.isAdmin = this._permissionChecker.isGranted("Pages.Users");
   console.log(this.isAdmin);
  }

  getAllActors(actorGender: string){
    this._actorService.getAll(actorGender)
    .pipe(
     finalize(() => {
       console.log("Error")
        //finishedCallback();
     })
   )
    .subscribe( data => { 
      console.log(data)
      this.actors=data.items;
      //this.totalItems=data.totalCount;
 
    });


  }

  createActor(): void {
    this.showCreateOrEditActor();
  }

  editActor(user: UserDto): void {
   // this.showCreateOrEditUserDialog(user.id);
  }

  

  clearFilters(): void {
    this.actorGender = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }

  protected list(
    request: PagedActorRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.actorGender = this.actorGender;
    request.isActive = this.isActive;

       this._actorService.getAll(request.actorGender)
    .pipe(
     finalize(() => {
       console.log("Error")
        finishedCallback();
     })
   )
    .subscribe( data => { 
      console.log(data)
      this.actors=data.items;
 
    });
  //   this._actorService
  //     .getAll(
  //       request.keyword,
  //       request.isActive,
  //       request.skipCount,
  //       request.maxResultCount
  //     )
  //     .pipe(
  //       finalize(() => {
  //         finishedCallback();
  //       })
  //     )
  //     .subscribe((result: UserDtoPagedResultDto) => {
  //       this.users = result.items;
  //       this.showPaging(result, pageNumber);
  //     });
   }

  protected delete(actor: ActorListDto): void {
    abp.message.confirm(
      this.l('UserDeleteWarningMessage', actor.actorName),
      undefined,
      (result: boolean) => {
        if (result) {
          this._actorService.deleteActor(actor.actorName,actor.actorGender,actor.id).subscribe(() => {
            abp.notify.success(this.l('SuccessfullyDeleted'));
            this.refresh();
          });
        }
      }
    );
  }

 
  private showCreateOrEditActor (id?: number): void {
    let createOrEditActor: BsModalRef;
    if (!id) {
      createOrEditActor = this._modalService.show(
        CreateActorComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditActor = this._modalService.show(
        EditActorComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditActor.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  

    
}
