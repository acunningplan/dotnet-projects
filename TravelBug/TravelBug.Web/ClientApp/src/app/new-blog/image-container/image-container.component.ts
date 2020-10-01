import { Component, Input, OnInit, EventEmitter, Output } from '@angular/core';
import { Image } from 'src/app/models/image';

@Component({
  selector: 'app-image-container',
  templateUrl: './image-container.component.html',
  styleUrls: ['./image-container.component.css']
})
export class ImageContainerComponent implements OnInit {
  @Input() photo: Image;
  @Input() id: number;
  @Output() clickDelete = new EventEmitter<number>();

  constructor() { }

  ngOnInit() {
  }

  onClickDelete() {
    this.clickDelete.emit(this.id);
  }
}
