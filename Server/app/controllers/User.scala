package controllers

import play.api._
import model._
import play.api.Play.current
import play.api.mvc._
import play.api.db._
import logging._
import java.sql.{Connection, DriverManager, ResultSet}

object User extends Controller {
  val Log = LogManager.Create("User")

  def patchesByInstrument(userId:String) = Action {
    Log.Log("returning patches for user")
    DB.withConnection{ implicit conn=>
      val statement = conn.createStatement(ResultSet.TYPE_FORWARD_ONLY, ResultSet.CONCUR_READ_ONLY)
      val query:String = "select model_id, name, patch_data from patches t1 inner join userpatches t2 on t1.id = t2.patchid AND t2.userid=%s".format(userId)
      val result = statement.executeQuery(query)

      var instruments:List[Instrument] = Nil
      var instrumentMap:Map[String, Instrument] = Map()


      while(result.next)
      {
        val instrumentId = result.getString("model_id")
        if(!instrumentMap.contains(instrumentId))
        {
          instrumentMap += (instrumentId -> new Instrument(instrumentId))
        }
        var instrument : Instrument = instrumentMap.get(instrumentId).get
        instrument.patches = instrument.patches ::: (new Patch(result.getString("name"), result.getString("patch_data")) :: Nil)

      }
      Ok(views.xml.userPatches(true, instrumentMap.values.toList))
    }
  }

  def savePatch(patchData:String) = Action {
    Ok(views.xml.savePatches())
  }

}
