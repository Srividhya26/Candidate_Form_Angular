import { Injectable } from '@angular/core';
import { FormGroup,FormControl,Validators,FormArray,FormBuilder, Form } from '@angular/forms';


@Injectable({
  providedIn: 'root'
})
export class StoreDetailsService {

  public professionalDetailsList : FormGroup;

  constructor(private list : FormBuilder) 
  {
    this.professionalDetailsList = this.list.group
    ({
      professional : this.list.array([this.createProfessionalDetails()]),
    })
   }

   createProfessionalDetails() : FormGroup
   {
       return this.list.group({
         company : new FormControl('',Validators.required),
         designation : new FormControl('',Validators.required),
         startDate : new FormControl('',Validators.required),
         endDate : new FormControl('',Validators.required),
         skills : new FormControl('',Validators.required)
       })

       this.professionalDetailsList.get('professional') as FormArray
   }

   get profDetailsFormGroup()
   {
     return this.professionalDetailsList.get('professional') as FormArray;
   }

   addProfDetail()
   {
     this.profDetailsFormGroup.push(this.createProfessionalDetails());
   }

   removeDetails(index : number)
   {
     this.profDetailsFormGroup.removeAt(index);
   }

  candidateForm = new FormGroup
  ({
    firstName : new FormControl('',Validators.required),
    lastName : new FormControl('',Validators.required),
    address : new FormControl('',Validators.required),
    phnNo : new FormControl('',[Validators.required,Validators.pattern('[- +()0-9]+')]),
    email : new FormControl('',[
        Validators.required,
        Validators.pattern('^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$')]),
    country : new FormControl('',Validators.required),
    state : new FormControl('',Validators.required)
  })

  attachmentDetail = new FormGroup(
    {
      uploadFiles : new FormControl('',Validators.required)
    }
  )
  
}
