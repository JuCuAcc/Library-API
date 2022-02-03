import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { RootComponent } from './root/root.component';
import { CategoryComponent } from './category/category.component';
import { AppRoutingModule } from './/app-routing.module';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CategoryService } from './category/category.service';
import { PublisherComponent } from './publisher/publisher.component';
import { AuthorComponent } from './author/author.component';
import { AuthorService } from './author/author.service';
import { PublisherService } from './publisher/publisher.service';



@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    RootComponent,
    CategoryComponent,
    PublisherComponent,
    AuthorComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,

    FormsModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [CategoryService, AuthorService, PublisherService, HttpClientModule],
  bootstrap: [AppComponent]
})
export class AppModule { }
