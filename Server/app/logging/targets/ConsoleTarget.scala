package logging.targets

import logging.ILogTarget

/**
 * Created by don on 1/24/15.
 */
class ConsoleTarget extends ILogTarget{
  def Write(message: String): Unit = {
    Console.println(message)
  }
}
