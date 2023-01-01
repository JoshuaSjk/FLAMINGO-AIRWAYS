import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms'
import { RouterModule, Routes, Router } from '@angular/router';
import ValidateForm from 'src/app/Helper/validateform';
import { UserManagerService } from 'src/app/services/usermanager.service';


@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})

export class SignupComponent implements OnInit {
  
  type:string = "password"
  isText: boolean = false;
  eyeIcon:string = "fa-eye-slash";
  signUpForm!: FormGroup;

  constructor(private fb : FormBuilder,
    private auth: UserManagerService,
    private router : Router){}

  ngOnInit(): void {
    this.signUpForm = this.fb.group({
      firstname: ['', Validators.required],
      lastname: ['', Validators.required],
      email: ['', Validators.required],
      username: ['', Validators.required],
      password: ['', Validators.required],
    })
  }

  hideShowPassword(){
    this.isText = !this.isText;
    this.isText ? this.eyeIcon="fa-eye" : this.eyeIcon="fa-eye-slash";
    this.isText ? this.type="text" : this.type="password";
  }

  onSignUp(){
    if(this.signUpForm.valid){

      console.log(this.signUpForm.value);

      this.auth.signUP(this.signUpForm.value).
      subscribe({
        next:(res=>{
          alert(res.message);
          //this.toast.success({detail:"SUCCESS", summary:res.message, duration=5000});
          this.signUpForm.reset();
          this.router.navigate(['login']);
        }),
        error:(err=>{
          alert(err?.error.message);
          //this.toast.error({detail:"ERROR", summary:err?.error.message,duration=5000});
        })
      })
    }
    else{

      console.log("Form is invalid");

      ValidateForm.validateAllFormFields(this.signUpForm);
      alert("Form is invalid");

    }
  }
}
