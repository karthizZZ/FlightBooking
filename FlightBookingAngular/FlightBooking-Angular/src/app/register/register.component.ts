import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../service/auth.service';
import { TokenStorageService } from '../service/token-storage.service';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  form: any = {
    firstname:null,
    lastname:null,
    email: null,
    password: null
  };
  isSuccessful = false;
  isSignUpFailed = false;
  errorMessage = '';
  constructor(private authService: AuthService, private tokenStorage: TokenStorageService,private router: Router) { }
  ngOnInit(): void {
    if (this.tokenStorage.getToken()) {
      this.router.navigate(['/home'])
      // this.roles = this.tokenStorage.getUser().roles;
    }
  }
  onSubmit(): void {
    const { firstname,lastname, email, password } = this.form;
    this.authService.register(firstname,lastname, email, password).subscribe(
      data => {
        console.log(data);
        this.tokenStorage.saveToken(data.token);
        this.tokenStorage.saveUser(data);
        window.location.reload();
      },
      err => {
        console.log(err);
        this.errorMessage = err.error.message;
        this.isSignUpFailed = true;
      }
    );
  }
}