package model

/**
 * Created by don on 1/27/15.
 */
class Instrument(id:String) {
  val dataId:String = id
  var patches:List[Patch] = Nil
}

class Patch(inName:String, inData:String)
{
  val name:String = inName
  val patchUTF:String = inData
}
