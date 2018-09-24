namespace TravelGuideTunisia.Business.Factories
{
    public class QueryCriteriaFactory
    {
       
        //#region SMS code Check

        //public static IQueryCriterion GetSMSCodeCheckCriteria<A>(SearchSMSCheckRequestModel model) where A : SMSShortCode
        //{
        //    var newResult = new Conjunction();
        //    newResult.Add(new NotNullCriterion<A>(c => c.Id));

        //    //if (!String.IsNullOrWhiteSpace(model.UserId))
        //    //    newResult.Add(new LikeCriterion<A>(c => c.UserId, model.UserId, true, MatchingMode.Anywhere));

        //    if (model.SmsCode !=null)
        //        newResult.Add(new LikeCriterion<A>(c => c.SmsCode, model.SmsCode.ToString(), true, MatchingMode.Anywhere));

        //    //if (!String.IsNullOrWhiteSpace(model.PhoneNumber))
        //    //    newResult.Add(new LikeCriterion<A>(c => c.PhoneNumber, model.PhoneNumber, true, MatchingMode.Anywhere));

        //    //if (!String.IsNullOrWhiteSpace(model.AppId))
        //    //    newResult.Add(new LikeCriterion<A>(c => c.AppId, model.AppId, true, MatchingMode.Anywhere));

        //    return newResult;
        //}
        //#endregion

    }
}
