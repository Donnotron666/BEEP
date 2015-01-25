package logging

/**
 * Created by don on 1/24/15.
 */
class Logger (name:String, targets:List[ILogTarget]) {

  private def LogName:String = name

  def Log(msg:String) : Unit = {

    val output = "[%s::%s] %s".format("Log", LogName, msg)
    for(target <- targets ) target.Write(output)
  }

  def Error(msg:String) : Unit = {
    val output = "[%s::%s] %s".format("Error", LogName, msg)
    for(target <- targets ) target.Write(output)
  }

  def Info(msg:String) : Unit = {
    val output = "[%s::%s] %s".format("Info", LogName, msg)
    for(target <- targets ) target.Write(output)
  }

  def Warn(msg:String) : Unit = {
    val output = "[%s::%s] %s".format("Warn", LogName, msg)
    for(target <- targets ) target.Write(output)
  }

}
