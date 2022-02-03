import { Component, OnInit } from '@angular/core';

import { Router} from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './root.component.html',
  styleUrls: ['./root.component.css']
})
export class RootComponent implements OnInit {

  constructor(private routes: Router) { }

  ngOnInit() {
  }

  UseMvc() {
    this.routes.navigate(['/home']);
    sessionStorage.setItem("url", "http://localhost:22421/api");
    localStorage.setItem("url", "http://localhost:22421/api");
  }

  UseCore() {
    this.routes.navigate(['/home']);
    sessionStorage.setItem("url", "http://localhost:22420/api");
    localStorage.setItem("url", "http://localhost:22420/api");
  }


}
