import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes} from '@angular/router';
import { SearchFligthComponent } from './core/search-fligth/search-fligth.component';

const routes: Routes =[
  {path:'search-flight', component: SearchFligthComponent},
  {path:'',redirectTo:'search-flight',pathMatch:'full'}
];

@NgModule({
  declarations: [],
  imports: [CommonModule, RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
