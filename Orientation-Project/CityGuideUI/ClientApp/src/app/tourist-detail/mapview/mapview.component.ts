import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-mapview',
  templateUrl: './mapview.component.html',
  styleUrls: ['./mapview.component.css']
})
export class MapviewComponent implements OnInit,AfterViewInit {
  //@ViewChild('myMap') myMap;
 @ViewChild(MapviewComponent, {static: false}) myMap
 //@ViewChild('ChildDirective') leafletmap; // using ViewChild to reference the div instead of setting an id
  public pageTitle: string = "Map";
ngOnInit(){

}
  ngAfterViewInit(){  // after the view completes initializaion, create the map
    var map = new Microsoft.Maps.Map(this.myMap.nativeElement, {
        credentials: 'AodPKbPz6ovYDYmKGuHtZNHwnHqqXQcsItBG02GdZ62Xmd7nSPhzap5imtqOeyNE'
    });
    var pushpin = new Microsoft.Maps.Pushpin(map.getCenter(), null);
    var layer = new Microsoft.Maps.Layer();
    layer.add(pushpin);
    map.layers.insert(layer);
  }
}

