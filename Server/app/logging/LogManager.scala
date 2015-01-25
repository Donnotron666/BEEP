package logging

/**
 * Created by don on 1/24/15.
 */
object LogManager {

  private var LogTargets:List[ILogTarget] = Nil

  def Create(name:String) : Logger = {
    return new Logger(name, LogTargets)
  }
  def AttachTarget(target:ILogTarget) = {
    LogTargets = LogTargets ::: (target :: Nil)
    Console.println("ATTACHING TARGET, new length %d".format(
      LogTargets.count(p=>true)
    ))

  }
}
