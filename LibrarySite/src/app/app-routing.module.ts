import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { Route, Router, RouterModule, Routes } from '@angular/router';
import { RootComponent} from './root/root.component';
import {HomeComponent } from './home/home.component';
import { CategoryComponent} from './category/category.component';

import { AuthorComponent } from './author/author.component';
import { PublisherComponent } from './publisher/publisher.component';

const routes: Routes = [
  {
    path: 'home', data: { title: 'Home' },
    children: [{ path: '', component: HomeComponent }]
  },
  {
    path: 'category', data: { title: 'Category' },
    children: [{ path: '', component: CategoryComponent }]
  },

  {
    path: 'author',
    data: { title: 'Author' },
    children: [{ path: '', component: AuthorComponent }]
  },

  {
    path: 'publisher',
    data: { title: 'Publisher' },
    children: [{ path: '', component: PublisherComponent }]
  },

  {path: "root", component: RootComponent},
  { path: "", redirectTo:'/root', pathMatch:'full'},
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports:[RouterModule],
  declarations: []
})
export class AppRoutingModule { }
