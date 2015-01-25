package controllers

import play.api._
import play.api.mvc._
import logging._

object Application extends Controller {

  LogManager.AttachTarget(new logging.targets.ConsoleTarget())
  val Log = LogManager.Create("Application")

  def index = Action {
    Log.Log("Going to index")
    Ok(views.html.index("Nothing to see here"))
  }

}