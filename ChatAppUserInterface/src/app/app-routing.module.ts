import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserComponent } from './user/user.component';
import { HomeComponent } from './home/home.component';
import { AccessdeniedComponent } from './accessdenied/accessdenied.component';
import { authGuard } from './guards/auth.guard';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';

const routes: Routes = [
  
  { path: "", redirectTo: "/login", pathMatch: "full" },
  {
    path: 'user', component: UserComponent,
  },
  { path: 'login', component: LoginComponent },
  { path: 'registration', component:RegistrationComponent},
  { path: 'home', component: HomeComponent, canActivate: [authGuard] },
  { path: 'accessdenied', component: AccessdeniedComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
