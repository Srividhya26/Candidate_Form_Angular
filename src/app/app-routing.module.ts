import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AttachmentsComponent } from './attachments/attachments.component';
import { PersonalDetailsComponent } from './personal-details/personal-details.component';
import { ProfessionalDetailsComponent } from './professional-details/professional-details.component';

const routes: Routes = [
  { path : 'personalDetails' , component : PersonalDetailsComponent},
  { path : 'professionalDetails' , component : ProfessionalDetailsComponent},
  { path : 'uploadDetails', component : AttachmentsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
