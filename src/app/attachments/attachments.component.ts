import { Component, OnInit } from '@angular/core';
import { StoreDetailsService } from '../store-details.service';

@Component({
  selector: 'app-attachments',
  templateUrl: './attachments.component.html',
  styleUrls: ['./attachments.component.css']
})
export class AttachmentsComponent implements OnInit {

  uploadDetails;
  constructor(public details : StoreDetailsService) 
  { 
    this.uploadDetails = details.attachmentDetail;
  }

  ngOnInit(): void {
  }

  submitForm()
  {
    alert("Details submitted successfully");
    console.log('submit form',this.uploadDetails.value);
  }

}
