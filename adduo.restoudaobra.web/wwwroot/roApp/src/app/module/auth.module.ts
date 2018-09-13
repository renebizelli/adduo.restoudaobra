import { NgModule } from "../../../node_modules/@angular/core"
import { AuthService } from "../service/auth.service"
import { SharedModule } from "./shared.module"

@NgModule({
  declarations: [AuthService],
  imports : [SharedModule],
  exports : [AuthService],
  providers : [AuthService]
})
export class  AuthModule {


}