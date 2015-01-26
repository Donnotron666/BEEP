package controllers
import play.api._
import play.api.mvc._
import logging._


/**
 * Created by don on 1/25/15.
 */


object Auth extends Controller {

  def authenticate() = Action {
    val id = "666";
    val email = "donnotron@gmail.com"
    val password = ""

    val isOk:Boolean = check(email, password);

    if(isOk)
    {
      Ok(views.xml.authOk()).withSession(Security.username -> id)
    } else {
      Ok(views.xml.authFailure())
    }
  }


  def check(email:String, password:String): Boolean =
  {
    return true
  }

}
