export class TypeHelper {

  static guidEmpty: string = '00000000-0000-0000-0000-000000000000'
  static stringEmpty: string = ''
  static any: any = {}


  public isNumber(test: string): boolean {
    return /^\d+$/.test(test)
  }

  public isEmpty(text: string): boolean {
      return text === TypeHelper.stringEmpty
  }

}
