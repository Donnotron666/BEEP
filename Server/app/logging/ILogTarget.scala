package logging

/**
 * Created by don on 1/24/15.
 */
trait ILogTarget {
  def Write(message:String) : Unit
}
