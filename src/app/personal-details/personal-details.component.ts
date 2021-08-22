import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { StoreDetailsService } from '../store-details.service';

@Component({
  selector: 'app-personal-details',
  templateUrl: './personal-details.component.html',
  styleUrls: ['./personal-details.component.css']
})
export class PersonalDetailsComponent implements OnInit {

  

  ngOnInit(): void {
  }

  personalForm : any;

  constructor(private router : Router,private personalDetails : StoreDetailsService)
  {
    this.personalForm = personalDetails.candidateForm;
  }

  
  states: Array<any> = [];
  selectedCountry: String = "--Choose Country--";

  Countries: Array<any> = [
		{ name: 'Germany', states:  [{name :'Saxony'}, {name :'Berlin'}]},
		{ name: 'Spain', states:  [{name: 'Palencia'} , {name : 'Avila'}] },
		{ name: 'USA', states: [{name: 'Texas'},{name : 'California'}] },
		{ name: 'Mexico', states:  [{name: 'Colima'} ,{name : 'Tabasco'}]},
		{ name: 'India', states:  [{name: 'Tamilnadu'} ,{name : 'Kerala' }]}
	];

  changeCountry(country: any) 
  { 
		this.states = this.Countries.find(con => con.name == country.target.value).states; 
	}

  goToNextPage()
  {
    this.router.navigate(['professionalDetails'])
    console.log(this.personalForm.value);
  }

}
