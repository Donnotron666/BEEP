package controllers

import play.api._
import play.api.mvc._
import logging._

object User extends Controller {
  val Log = LogManager.Create("User")

  def patches(id:Long) = Action {
    Ok(views.html.index("Getting patches for user %d".format(id)))
  }

}
