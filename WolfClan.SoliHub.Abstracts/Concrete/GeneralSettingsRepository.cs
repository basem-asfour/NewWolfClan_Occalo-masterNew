using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WolfClan.SoliHub.Abstracts.Contracts;
using WolfClan.SoliHub.Abstracts.Contracts.Base;
using WolfClan.SoliHub.Messages.Base;
using WolfClan.SoliHub.Models.ViewModels;

namespace WolfClan.SoliHub.Abstracts.Concrete
{
    public class GeneralSettingsRepository : RepositoryBase<GeneralSettingsVM>, IGeneralSettingsRepository
    {
        private readonly string connectionString;
        private readonly IDapperManager dapperManager;

        public GeneralSettingsRepository(string ConnectionString, IDapperManager dapperManager) : base(ConnectionString)
        {
            connectionString = ConnectionString;
            this.dapperManager = dapperManager;
        }

        public async override Task<IResponseMessage<GeneralSettingsVM>> Add(GeneralSettingsVM obj)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("TitleEN", obj.TitleEN ?? "", DbType.String);
            dbPara.Add("TitleAR", obj.TitleAR ?? "", DbType.String);
            dbPara.Add("WelWordsEN", obj.WelWordsEN ?? "", DbType.String);
            dbPara.Add("WelWordsAR", obj.WelWordsAR ?? "", DbType.String);
            dbPara.Add("MetaDesc", obj.MetaDesc ?? "", DbType.String);
            dbPara.Add("MetaKW", obj.MetaKW ?? "", DbType.String);
            dbPara.Add("Facebook", obj.Facebook ?? "", DbType.String);
            dbPara.Add("Twitter", obj.Twitter, DbType.Int32);

            dbPara.Add("Instagram", obj.Instagram ?? "", DbType.String);
            dbPara.Add("Youtube", obj.Youtube ?? "", DbType.String);
            dbPara.Add("Linkedin", obj.Linkedin ?? "", DbType.String);
            dbPara.Add("AppStore", obj.AppStore ?? "", DbType.String);
            dbPara.Add("GooglePlay", obj.GooglePlay ?? "", DbType.String);
            dbPara.Add("Address", obj.Address ?? "", DbType.String);
            dbPara.Add("Email", obj.Email ?? "", DbType.String);
            dbPara.Add("Phone", obj.Phone, DbType.Int32);

            dbPara.Add("Fax", obj.Fax ?? "", DbType.String);
            dbPara.Add("DefaultCountryId", obj.DefaultCountryId, DbType.Int32);
            dbPara.Add("Latitude", obj.Latitude ?? "", DbType.String);
            dbPara.Add("Longitude", obj.Longitude ?? "", DbType.String);
            dbPara.Add("PageSize", obj.PageSize, DbType.Int32);
            dbPara.Add("PageSizeMob", obj.PageSizeMob, DbType.Int32);
            dbPara.Add("AutoActiveUser", obj.AutoActiveUser, DbType.Int32);
            dbPara.Add("AutoActiveArticle", obj.AutoActiveArticle, DbType.Int32);

            dbPara.Add("AddedOn", obj.AddedOn, DbType.DateTime);
            dbPara.Add("ModifiedOn", obj.ModifiedOn, DbType.DateTime);
            dbPara.Add("AdminUserId", obj.AdminUserId, DbType.Int32);

            string SQL = $"INSERT INTO dbo.GeneralSettings ";
            SQL += " (TitleEN, TitleAR, WelWordsEN, WelWordsAR, MetaDesc, MetaKW, Facebook, Twitter, Instagram, Youtube, Linkedin, AppStore, GooglePlay, Address, Email, Phone, Fax, DefaultCountryId, Latitude, Longitude, PageSize, ";
            SQL += " PageSizeMob, AutoActiveUser, AutoActiveArticle, AddedOn, ModifiedOn, AdminUserId) ";
            SQL += " VALUES (@TitleEN,@TitleAR,@WelWordsEN,@WelWordsAR,@MetaDesc,@MetaKW,@Facebook,@Twitter,@Instagram,@Youtube,@Linkedin,@AppStore,@GooglePlay,@Address,@Email,@Phone,@Fax,@DefaultCountryId,@Latitude,@Longitude,@PageSize,@PageSizeMob,@AutoActiveUser,@AutoActiveArticle,@AddedOn,@ModifiedOn,@AdminUserId) select @@identity; ";
            try
            {
                var newID = await Task.FromResult(dapperManager.Insert<int>(SQL, dbPara, CommandType.Text));

                if (newID > 0)
                {
                    obj.Id = newID;
                    return new ResponseMessageBase<GeneralSettingsVM>() { MessageType = MessageTypes.Success, ResponseData = new[] { obj } };
                }

                return new ResponseMessageBase<GeneralSettingsVM>() { MessageType = MessageTypes.Error, ResponseData = null };
            }
            catch (Exception ex)
            { return new ResponseMessageBase<GeneralSettingsVM>() { MessageType = MessageTypes.Error, ResponseData = null, exception = ex }; }

        }

        public override void Dispose()
        {
            if (dapperManager != null) { dapperManager.Dispose(); }
        }

        public async override Task<IResponseMessage<GeneralSettingsVM>> GetAll(QueryParameters request)
        {
            string sql = "";


            


            var dbPara = new DynamicParameters();


            #region Page and filter code sample Codes
            //string filter = string.IsNullOrEmpty(request.filter) ? "" :request.filter;
            //dbPara.Add("@Filter", (string.IsNullOrEmpty(filter) ? "" : filter.ToLower()), DbType.String);
            //dbPara.Add("@Offset", request.Offset, DbType.Int32);
            //dbPara.Add("@Next", request.Next, DbType.Int32);

            //string order = "";
            //if (string.IsNullOrEmpty(request.OrderBy))
            //{
            //    order = "BranchID";
            //}
            //else { order = request.OrderBy; }

            //sql = "; with pagedDT as ";
            //sql += " ( ";
            //sql += " select *, ROW_NUMBER() OVER(ORDER BY " + order + " " + request.SortDirection + ") AS rowNumber from tb_branches ";
            //if (!string.IsNullOrEmpty(request.filter))
            //{
            //    sql += " where (Lower(BranchName) like  '%'+@Filter+'%' )  ";
            //}
            //sql += " ) ";
            //sql += " select *,(select Count(*) from tb_branches) as TotalCount from pagedDT ";
            //sql += " where ";
            //sql += " (rowNumber > @Offset and rowNumber<= @Next) ";


            //if (settings != null && settings.Count > 0 && !string.IsNullOrEmpty(request.filter))
            //{
            //    settings[0].TotalCount = settings.Count();
            //}
            #endregion


            sql = "select * from dbo.GeneralSettings";



            var settings = await Task.FromResult(dapperManager.GetAll<GeneralSettingsVM>(sql, dbPara, commandType: CommandType.Text));


            return new ResponseMessageBase<GeneralSettingsVM>() { MessageType = MessageTypes.Success, ResponseData = settings };

        }

        public async override Task<IResponseMessage<GeneralSettingsVM>> GetById(int? id)
        {
            var dbParams = new DynamicParameters();
            dbParams.Add("@Id", id, DbType.Int32);

            string sql = $"select * from [dbo].[GeneralSettings] WHERE Id = @Id";
            var Branch = await Task.FromResult(dapperManager.Get<GeneralSettingsVM>(sql, dbParams, CommandType.Text));
            return new ResponseMessageBase<GeneralSettingsVM>() { MessageType = MessageTypes.Success, ResponseData = new[] { Branch } };

        }

        public IDbConnection GetOpenConnection()
        {
            return dapperManager.GetConnection();
        }

        public async override Task<IResponseMessage<GeneralSettingsVM>> Remove(GeneralSettingsVM obj)
        {
            if (obj == null || obj.Id <= 0) { return new ResponseMessageBase<GeneralSettingsVM>() { MessageType = MessageTypes.NotFound, ResponseData = null }; }
            var dbParams = new DynamicParameters();
            dbParams.Add("@Id", obj.Id, DbType.Int32);
            string sql = $"delete  from [dbo].[GeneralSettings] WHERE Id = @Id";
            var Branch = await Task.FromResult(dapperManager.Execute(sql, dbParams, CommandType.Text));
            return new ResponseMessageBase<GeneralSettingsVM>() { MessageType = MessageTypes.Success, ResponseData = new[] { obj } };

        }

        public async override Task<IResponseMessage<GeneralSettingsVM>> Remove(int? id)
        {
            if (id == null || id <= 0) { return new ResponseMessageBase<GeneralSettingsVM>() { MessageType = MessageTypes.NotFound, ResponseData = null }; }
            var dbParams = new DynamicParameters();
            dbParams.Add("@Id", id, DbType.Int32);
            string sql = $"delete  from [dbo].[GeneralSettings] WHERE Id = @Id";
            var res = await Task.FromResult(dapperManager.Execute(sql, dbParams, CommandType.Text));
            return new ResponseMessageBase<GeneralSettingsVM>() { MessageType = MessageTypes.Success, ResponseData = null };
        }

        public async override Task<IResponseMessage<GeneralSettingsVM>> Update(GeneralSettingsVM obj)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("Id", obj.Id , DbType.Int32);
            dbPara.Add("TitleEN", obj.TitleEN ?? "", DbType.String);
            dbPara.Add("TitleAR", obj.TitleAR ?? "", DbType.String);
            dbPara.Add("WelWordsEN", obj.WelWordsEN ?? "", DbType.String);
            dbPara.Add("WelWordsAR", obj.WelWordsAR ?? "", DbType.String);
            dbPara.Add("MetaDesc", obj.MetaDesc ?? "", DbType.String);
            dbPara.Add("MetaKW", obj.MetaKW ?? "", DbType.String);
            dbPara.Add("Facebook", obj.Facebook ?? "", DbType.String);
            dbPara.Add("Twitter", obj.Twitter, DbType.Int32);

            dbPara.Add("Instagram", obj.Instagram ?? "", DbType.String);
            dbPara.Add("Youtube", obj.Youtube ?? "", DbType.String);
            dbPara.Add("Linkedin", obj.Linkedin ?? "", DbType.String);
            dbPara.Add("AppStore", obj.AppStore ?? "", DbType.String);
            dbPara.Add("GooglePlay", obj.GooglePlay ?? "", DbType.String);
            dbPara.Add("Address", obj.Address ?? "", DbType.String);
            dbPara.Add("Email", obj.Email ?? "", DbType.String);
            dbPara.Add("Phone", obj.Phone, DbType.Int32);

            dbPara.Add("Fax", obj.Fax ?? "", DbType.String);
            dbPara.Add("DefaultCountryId", obj.DefaultCountryId, DbType.Int32);
            dbPara.Add("Latitude", obj.Latitude ?? "", DbType.String);
            dbPara.Add("Longitude", obj.Longitude ?? "", DbType.String);
            dbPara.Add("PageSize", obj.PageSize, DbType.Int32);
            dbPara.Add("PageSizeMob", obj.PageSizeMob, DbType.Int32);
            dbPara.Add("AutoActiveUser", obj.AutoActiveUser, DbType.Int32);
            dbPara.Add("AutoActiveArticle", obj.AutoActiveArticle, DbType.Int32);

            dbPara.Add("AddedOn", obj.AddedOn, DbType.DateTime);
            dbPara.Add("ModifiedOn", obj.ModifiedOn, DbType.DateTime);
            dbPara.Add("AdminUserId", obj.AdminUserId, DbType.Int32);

            string SQL = $"UPDATE dbo.GeneralSettings ";
            SQL += " SET	TitleEN = @TitleEN, TitleAR = @TitleAR, WelWordsEN = @WelWordsEN, WelWordsAR = @WelWordsAR, MetaDesc = @MetaDesc, MetaKW = @MetaKW,  ";
            SQL += " Facebook = @Facebook, Twitter = @Twitter, Instagram = @Instagram, Youtube = @Youtube, Linkedin = @Linkedin, AppStore = @AppStore, GooglePlay = @GooglePlay, [Address] = @Address, Email = @Email, Phone = @Phone,  ";
            SQL += " Fax = @Fax, DefaultCountryId = @DefaultCountryId, Latitude = @Latitude, Longitude = @Longitude, PageSize = @PageSize, PageSizeMob = @PageSizeMob, AutoActiveUser = @AutoActiveUser,  ";
            SQL += " AutoActiveArticle = @AutoActiveArticle, AddedOn = @AddedOn, ModifiedOn = @ModifiedOn, AdminUserId = @AdminUserId ";
            SQL += " WHERE (Id = @Id)  select @@RowCount; ";
            try
            {
                var newID = await Task.FromResult(dapperManager.Insert<int>(SQL, dbPara, CommandType.Text));

                if (newID > 0)
                {
                    return new ResponseMessageBase<GeneralSettingsVM>() { MessageType = MessageTypes.Success, ResponseData = new[] { obj } };
                }

                return new ResponseMessageBase<GeneralSettingsVM>() { MessageType = MessageTypes.Error, ResponseData = null };
            }
            catch (Exception ex)
            { return new ResponseMessageBase<GeneralSettingsVM>() { MessageType = MessageTypes.Error, ResponseData = null, exception = ex }; }

        }
    }
}
