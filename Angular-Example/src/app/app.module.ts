import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { BMICalculatorComponent } from './bmicalculator/bmicalculator.component';
import { SecretPointComponent } from './secret-point/secret-point.component';

@NgModule({
  declarations: [AppComponent, BMICalculatorComponent, SecretPointComponent],
  imports: [BrowserModule, FormsModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
