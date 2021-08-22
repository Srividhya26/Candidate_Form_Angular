import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { StoreDetailsService } from '../store-details.service';

@Component({
  selector: 'app-professional-details',
  templateUrl: './professional-details.component.html',
  styleUrls: ['./professional-details.component.css']
})
export class ProfessionalDetailsComponent implements OnInit 
{

  professionalDetail;

  constructor( private router : Router,public profDetails : StoreDetailsService) { 
    this.professionalDetail = profDetails.professionalDetailsList;
  }

  ngOnInit(): void {
  }

  addNewDetail()
  {
    this.profDetails.addProfDetail();
  }

  removeDetail(index : number)
  {
    this.profDetails.removeDetails(index);
  }

  getFormControl(id : number,controlName : string)
  {
    return this.professionalDetail
    .get(`professional.${id}`) 
    ?.get(controlName) as FormGroup 
  }
  
  goToNextPage()
  {
    this.router.navigate(['uploadDetails']);
    console.log(this.professionalDetail.value);
  }
    
}


