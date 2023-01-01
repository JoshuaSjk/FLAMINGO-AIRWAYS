import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms'
import { Router } from '@angular/router';
import ValidateForm from 'src/app/Helper/validateform';
import { UserManagerService } from 'src/app/services/usermanager.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {

  constructor(private fb:FormBuilder, private auth: UserManagerService, private router: Router){}


  type:string = "password"
  isText: boolean = false;
  eyeIcon:string = "fa-eye-slash";
  loginForm!: FormGroup;

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    })
  }

  hideShowPassword(){
    this.isText = !this.isText;
    this.isText ? this.eyeIcon="fa-eye" : this.eyeIcon="fa-eye-slash";
    this.isText ? this.type="text" : this.type="password";
  }

  onLogin(){
    if(this.loginForm.valid){

      console.log(this.loginForm.value);
      this.auth.login(this.loginForm.value).
      subscribe({
        next:(res=>{
          alert(res.message);
          //this.toast.success({detail:"SUCCESS", summary:res.message});
          this.loginForm.reset();
          this.router.navigate(['dashboard']);
        }),
        error:(err=>{
          alert(err?.error.message);
          //this.toast.error({detail:"ERROR", summary:err?.error.message});
        })
      })
    }
    else{

      console.log("Form is invalid");

      ValidateForm.validateAllFormFields(this.loginForm);
      alert("Form is invalid");

    }
  }

  }

