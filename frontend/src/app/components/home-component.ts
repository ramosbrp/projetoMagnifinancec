import { Component, OnInit } from '@angular/core';
import { MyService } from '../services/service';

@Component({
    selector: 'app-home',
    templateUrl: './app.home.component.html',
    styleUrls: ['./app.home.component.css']
})

export class HomeComponent implements OnInit {
    constructor(private myService: MyService) {}

    ngOnInit(): void {
        this.myService.getSomething().subscribe(
            data => {console.log(data)}
        )
    }
}