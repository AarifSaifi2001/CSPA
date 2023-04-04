import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FileUploader } from 'ng2-file-upload';
import { Car } from 'src/app/Models/car';
import { Photo } from 'src/app/Models/photos';
import { AlertifyService } from 'src/app/Services/alertify.service';
import { CarService } from 'src/app/Services/car.service';

@Component({
  selector: 'app-photo-editor',
  templateUrl: './photo-editor.component.html',
  styleUrls: ['./photo-editor.component.css']
})
export class PhotoEditorComponent implements OnInit {

  @Input() car: Car;
  @Output() mainPhotoChangedEvent = new EventEmitter<string>();

  uploader: FileUploader;
  maxAllowedFileSize = 10*1024*1024;

  constructor(private carServ: CarService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.initializeFileUploader();
  }

  initializeFileUploader(){
    this.uploader = new FileUploader({
      url: "http://localhost:5000/api/car/add/photo/"+String(this.car.id),
      authToken: 'Bearer '+ localStorage.getItem('token'),
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: true,
      maxFileSize: this.maxAllowedFileSize
    });

    this.uploader.onAfterAddingFile = (file) =>{
      file.withCredentials = false;
    }

    this.uploader.onSuccessItem = (item, response, status, headers) => {
      if(response){
        const photo = JSON.parse(response);
        this.car.photos.push(photo);
        this.alertify.success("Photo uploaded successfully");
      }
    }
  }

  mainPhotoChanged(url: string){
    this.mainPhotoChangedEvent.emit(url);
  }

  setPrimaryPhoto(carId: number, photo: Photo){

    this.carServ.setPrimaryPhoto(carId, photo.publicId).subscribe(() => {
      this.mainPhotoChanged(photo.imageUrl);
      this.car.photos.forEach(p => {
        if(p.isPrimary) {p.isPrimary = false;}
        if(p.publicId === photo.publicId) {p.isPrimary = true;}
      });
    });
  }

  deletePhoto(carId: number, photo: Photo){

    if(confirm("Are you sure to delete this photo"))
      this.carServ.deletePhoto(carId, photo.publicId).subscribe(()=> {
        this.car.photos = this.car.photos.filter(p => p.publicId !== photo.publicId);
      });
  }
}
