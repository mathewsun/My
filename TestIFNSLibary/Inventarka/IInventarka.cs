﻿using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Threading.Tasks;
using EfDatabase.Inventory.Base;
using EfDatabase.Inventory.BaseLogic.AddObjectDb;
using EfDatabase.Inventory.ReportXml.ReturnModelError;
using EfDatabaseParametrsModel;
using EfDatabaseXsdBookAccounting;
using SqlLibaryIfns.Inventory.ModelParametr;
using Printer = EfDatabase.Inventory.Base.Printer;
using ScanerAndCamer = EfDatabase.Inventory.Base.ScanerAndCamer;
using SysBlock = EfDatabase.Inventory.Base.SysBlock;
using User = EfDatabase.Inventory.Base.User;

namespace TestIFNSLibary.Inventarka
{
   [ServiceContract]
   public interface IInventarka
   {



        /// <summary>
        /// http://localhost:8182/Inventarka/GenerateSqlSelect
        /// Генерация запросов на клиент
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/GenerateSqlSelect", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<ModelSelect> GenerateSqlSelect(ModelSelect user);

        /// <summary>
        /// http://localhost:8182/Inventarka/GenerateTelephoneHelper
        /// Генерация телефонного справочника инспекции
        /// </summary>
        /// <returns>Телефонный справочник инспекции</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/GenerateTelephoneHelper", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<Stream> GenerateTelephoneHelper(ModelSelect telephonehelper);

        /// <summary>
        /// http://localhost:8182/Inventarka/GenerateBookAccounting
        /// Генерация книги учета материальных ценностей
        /// </summary>
        /// <returns>Книга учета материальных ценностей</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/GenerateBookAccounting", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<Stream> GenerateBookAccounting(BookModels bookModels);

        /// <summary>
        /// http://localhost:8182/Inventarka/Autification
        /// Авторизация для ресурса Инвентаризация
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/Authorization", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<string> Authorization(User user);

        /// <summary>
        /// Выбор всех пользователей c SQL запроса
        /// http://localhost:8182/Inventarka/SelectDb
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/SelectDb", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
       Task<string> SelectAllUsers(ModelParametr model);
        /// <summary>
        /// Все отделы в БД
        /// http://localhost:8182/Inventarka/AllOtdels
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AllOtdels", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<string> AllOtdels();
        /// <summary>
        /// Все роли в БД
        /// http://localhost:8182/Inventarka/AllRules
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET",RequestFormat = WebMessageFormat.Json,UriTemplate = "/AllRules",ResponseFormat = WebMessageFormat.Json,BodyStyle = WebMessageBodyStyle.Bare)]
        Task<string> AllRules();
        /// <summary>
        /// Все пользователи 
        /// http://localhost:8182/Inventarka/AllUsers
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AllUsers",  ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<string> AllUsers();

        /// <summary>
        /// Статистика обраьботки пользователей процедурой
        /// http://localhost:8182/Inventarka/AllActualsProcedureUsers
        /// </summary>
        /// <returns></returns>
       [OperationContract]
       [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AllActualsProcedureUsers", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
       Task<string> AllActualsProcedureUsers();

        /// <summary>
        /// Все пользователи 
        /// http://localhost:8182/Inventarka/AllPosition
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AllPosition", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<string> AllPosition();

        /// <summary>
        /// Все пользователи 
        /// http://localhost:8182/Inventarka/AllClasification
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AllClasification", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<string> AllClasification();


        /// <summary>
        /// Все принтеры
        /// http://localhost:8182/Inventarka/AllPrinters
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AllPrinters", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<string> AllPrinters();

        /// <summary>
        /// Все коммутаторы
        /// http://localhost:8182/Inventarka/AllSwithes
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AllSwithes", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<string> AllSwithes();

        /// <summary>
        /// Все модели коммутаторов
        /// http://localhost:8182/Inventarka/AllModelSwithes
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AllModelSwithes", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<string> AllModelSwithes();

        /// <summary>
        /// Все сканеры
        /// http://localhost:8182/Inventarka/AllScaners
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AllScaners", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<string> AllScaners();

        /// <summary>
        /// Все МФУ
        /// http://localhost:8182/Inventarka/AllMfu
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AllMfu", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<string> AllMfu();

        /// <summary>
        /// Все Системные блоки
        /// http://localhost:8182/Inventarka/AllSysBlok
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AllSysBlok", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<string> AllSysBlok();

        /// <summary>
        /// Все Мониторы
        /// http://localhost:8182/Inventarka/AllMonitors
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AllMonitors", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<string> AllMonitors();

        /// <summary>
        /// Все Производители системных блоков
        /// http://localhost:8182/Inventarka/AllNameSysBlock
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AllNameSysBlock", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<string> NameSysBlock();

        /// <summary>
        /// Все Производители мониторов
        /// http://localhost:8182/Inventarka/AllNameMonitor
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AllNameMonitor", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<string> NameMonitor();

        /// <summary>
        /// Все CopySave
        /// http://localhost:8182/Inventarka/AllCopySave
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AllCopySave", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<string> CopySave();

        /// <summary>
        /// Все производители
        /// http://localhost:8182/Inventarka/AllProizvoditel
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AllProizvoditel", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<string> Proizvoditel();

        /// <summary>
        /// Все производители
        /// http://localhost:8182/Inventarka/AllModel
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AllModel", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<string> Model();
        /// <summary>
        /// Все кабинеты
        /// http://localhost:8182/Inventarka/AllKabinet
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AllKabinet", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<string> Kabinet();
        /// <summary>
        /// Все телефоны
        /// http://localhost:8182/Inventarka/AllTelephon
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AllTelephon", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<string> Telephon();
        /// <summary>
        /// Все бесперебойники
        /// http://localhost:8182/Inventarka/AllBlockPower
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AllBlockPower", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<string> BlockPower();
        /// <summary>
        /// Все поставщики
        /// http://localhost:8182/Inventarka/AllSupply
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AllSupply", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<string> Supply();
        /// <summary>
        /// Все модели бесперебойников
        /// http://localhost:8182/Inventarka/AllModelBlockPower
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AllModelBlockPower", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<string> ModelBlockPower();
        /// <summary>
        /// Все производители бесперебойников
        /// http://localhost:8182/Inventarka/AllProizvoditelBlockPower
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AllProizvoditelBlockPower", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<string> ProizvoditelBlockPower();
        /// <summary>
        /// Все статусы
        /// http://localhost:8182/Inventarka/AllStatusing
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AllStatusing", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<string> Statusing();
        /// <summary>
        /// Добавление или обновление пользователя
        /// http://localhost:8182/Inventarka/AddAndEditUser
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <param name="userIdEdit">Кто редактировал</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AddAndEditUser?userIdEdit={userIdEdit}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ModelReturn<User> AddAndEditUser(User user,string userIdEdit);
        /// <summary>
        /// Добавление принтера
        /// http://localhost:8182/Inventarka/AddAndEditPrinter
        /// </summary>
        /// <param name="printer"></param>
        /// <param name="userIdEdit">Кто редактировал</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AddAndEditPrinter?userIdEdit={userIdEdit}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ModelReturn<Printer> AddAndEditPrinter(Printer printer, string userIdEdit);

        /// <summary>
        /// Добавление Коммутатора
        /// http://localhost:8182/Inventarka/AddAndEditSwith
        /// </summary>
        /// <param name="swith"></param>
        /// <param name="userIdEdit">Кто редактировал</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AddAndEditSwith?userIdEdit={userIdEdit}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ModelReturn<EfDatabase.Inventory.Base.Swithe> AddAndEditSwith(EfDatabase.Inventory.Base.Swithe swith, string userIdEdit);

        /// <summary>
        /// Добавление модели Коммутатора
        /// http://localhost:8182/Inventarka/AddAndEditModelSwith
        /// </summary>
        /// <param name="modelswith"></param>
        /// <returns></returns>
        [OperationContract]
       [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AddAndEditModelSwith",
           ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
       ModelReturn<EfDatabase.Inventory.Base.ModelSwithe> AddAndEditModelSwith(EfDatabase.Inventory.Base.ModelSwithe modelswith);
        /// <summary>
        /// Добавление сканера
        /// http://localhost:8182/Inventarka/AddAndEditScaner
        /// </summary>
        /// <param name="scaner"></param>
        /// <param name="userIdEdit">Кто редактировал</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AddAndEditScaner?userIdEdit={userIdEdit}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ModelReturn<EfDatabase.Inventory.Base.ScanerAndCamer> AddAndEditScaner(EfDatabase.Inventory.Base.ScanerAndCamer scaner, string userIdEdit);

        /// <summary>
        /// Добавление или обновление мфу
        /// http://localhost:8182/Inventarka/AddAndEditMfu
        /// </summary>
        /// <param name="mfu"></param>
        /// <param name="userIdEdit">Кто редактировал</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AddAndEditMfu?userIdEdit={userIdEdit}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ModelReturn<EfDatabase.Inventory.Base.Mfu> AddAndEditMfu(EfDatabase.Inventory.Base.Mfu mfu, string userIdEdit);

        /// <summary>
        /// Добавление или обновление Системного блока
        /// http://localhost:8182/Inventarka/AddAndEditSysBlok
        /// </summary>
        /// <param name="sysblock"></param>
        /// <param name="userIdEdit">Кто редактировал</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AddAndEditSysBlok?userIdEdit={userIdEdit}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ModelReturn<SysBlock> AddAndEditSysBlok(SysBlock sysblock, string userIdEdit);

        /// <summary>
        /// Добавление или обновление Монитора
        /// http://localhost:8182/Inventarka/AddAndEditMonitor
        /// </summary>
        /// <param name="monitor"></param>
        /// <param name="userIdEdit">Кто редактировал</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AddAndEditMonitor?userIdEdit={userIdEdit}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ModelReturn<Monitor> AddAndEditMonitor(Monitor monitor, string userIdEdit);

        /// <summary>
        /// Добавление или обновление Монитора
        /// http://localhost:8182/Inventarka/AddAndEditOtdel
        /// </summary>
        /// <param name="otdel"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AddAndEditOtdel", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ModelReturn<EfDatabase.Inventory.Base.Otdel> AddAndEditOtdel(EfDatabase.Inventory.Base.Otdel otdel);


        /// <summary>
        /// Добавление или обновление Монитора
        /// http://localhost:8182/Inventarka/SelectXml
        /// </summary>
        /// <param name="logica"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/SelectXml", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<string> SelectXml(EfDatabaseParametrsModel.LogicaSelect logica);
        /// <summary>
        /// Удаление документа
        /// http://localhost:8182/Inventarka/DeleteDocument
        /// </summary>
        /// <param name="iddoc">Ун документа</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/DeleteDocument", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string DeleteDocument(int iddoc);

        /// <summary>
        /// Загрузка документа на внутренее перемещение
        /// http://localhost:8182/Inventarka/LoadDocument
        /// </summary>
        /// <param name="iddoc">Ун документа</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/LoadDocument", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Stream LoadDocument(int iddoc);

        /// <summary>
        /// Загрузка книги учета
        /// http://localhost:8182/Inventarka/LoadBook
        /// </summary>
        /// <param name="iddoc">Ун книги учета</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/LoadBook", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Stream LoadBook(int iddoc);


        /// <summary>
        /// Создание накладной на внутреннее перемещение
        /// http://localhost:8182/Inventarka/Invoice
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/Invoice", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<Stream> GenerateDocuments(EfDatabaseInvoice.Report report);

        /// <summary>
        /// Прием файла с сайта 
        /// http://localhost:8182/Inventarka/AddFileDb
        /// </summary>
        /// <param name="uploadFileModel">Модель с файлами tiff/tif</param>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AddFileDb", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ModelError[] AddFileToDb(EfDatabaseUploadFile.UploadFile uploadFileModel);
        /// <summary>
        /// Актулизация пользователей с БД кадрами
        /// http://localhost:8182/Inventarka/ActualUsers
        /// </summary>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/ActualUsers", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<string> ActualUsers();
        /// <summary>
        /// Актулизация пользователей с БД кадрами
        /// http://localhost:8182/Inventarka/ActualComputerIp
        /// </summary>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/ActualComputerIp", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<string> ActualComputerIp();
        /// <summary>
        /// Добавление или обновление Телефона
        /// http://localhost:8182/Inventarka/AddAndEditTelephone?userIdEdit={userIdEdit}
        /// Но зачем мне сдесь Id Users SignalR? не понял если только уведомления отсылать в статический класс Возможно!!!
        /// </summary>
        /// <param name="telephon">Телефон</param>
        /// <param name="userIdEdit">Пользователь кто редактировал</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AddAndEditTelephone?userIdEdit={userIdEdit}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ModelReturn<EfDatabase.Inventory.Base.Telephon> AddAndEditTelephon(EfDatabase.Inventory.Base.Telephon telephon, string userIdEdit);
        /// <summary>
        /// Добавление или обновление Телефона
        /// http://localhost:8182/Inventarka/AddAndEditBlockPower
        /// </summary>
        /// <param name="blockpower">Источник бесперебойного питания</param>
        /// <param name="userIdEdit">Пользователь кто редактировал</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AddAndEditBlockPower?userIdEdit={userIdEdit}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ModelReturn<EfDatabase.Inventory.Base.BlockPower> AddAndEditBlockPower(EfDatabase.Inventory.Base.BlockPower blockpower, string userIdEdit);
        /// <summary>
        /// Добавление или обновление наименование системного блока
        /// http://localhost:8182/Inventarka/AddAndEditNameSysBlock
        /// </summary>
        /// <param name="nameSysBlock"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AddAndEditNameSysBlock", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ModelReturn<EfDatabase.Inventory.Base.NameSysBlock> AddAndEditNameSysBlock(EfDatabase.Inventory.Base.NameSysBlock nameSysBlock);

        /// <summary>
        /// Добавление или обновление наименование монитора
        /// http://localhost:8182/Inventarka/AddAndEditNameMonitor
        /// </summary>
        /// <param name="nameMonitor"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AddAndEditNameMonitor", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ModelReturn<EfDatabase.Inventory.Base.NameMonitor> AddAndEditNameMonitor(EfDatabase.Inventory.Base.NameMonitor nameMonitor);

        /// <summary>
        /// Добавление или обновление наименование модель ИБП
        /// http://localhost:8182/Inventarka/AddAndEditNameModelBlokPower
        /// </summary>
        /// <param name="nameModelBlokPower"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AddAndEditNameModelBlokPower", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ModelReturn<EfDatabase.Inventory.Base.ModelBlockPower> AddAndEditNameModelBlokPower(EfDatabase.Inventory.Base.ModelBlockPower nameModelBlokPower);

        /// <summary>
        /// Добавление или обновление наименование производителя ИБП
        /// http://localhost:8182/Inventarka/AddAndEditNameProizvoditelBlockPower
        /// </summary>
        /// <param name="nameProizvoditelBlockPower"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AddAndEditNameProizvoditelBlockPower", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ModelReturn<EfDatabase.Inventory.Base.ProizvoditelBlockPower> AddAndEditNameProizvoditelBlockPower(EfDatabase.Inventory.Base.ProizvoditelBlockPower nameProizvoditelBlockPower);

        /// <summary>
        /// Добавление или обновление наименование наименование партии
        /// http://localhost:8182/Inventarka/AddAndEditNameSupply
        /// </summary>
        /// <param name="nameSupply"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AddAndEditNameSupply", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ModelReturn<EfDatabase.Inventory.Base.Supply> AddAndEditNameSupply(EfDatabase.Inventory.Base.Supply nameSupply);

        /// <summary>
        /// Добавление или обновление наименование статуса
        /// http://localhost:8182/Inventarka/AddAndEditNameStatus
        /// </summary>
        /// <param name="nameStatus"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AddAndEditNameStatus", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ModelReturn<Statusing> AddAndEditNameStatus(Statusing nameStatus);

        /// <summary>
        /// Добавление или обновление наименование кабинета
        /// http://localhost:8182/Inventarka/AddAndEditNameKabinet
        /// </summary>
        /// <param name="nameKabinet"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AddAndEditNameKabinet", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ModelReturn<EfDatabase.Inventory.Base.Kabinet> AddAndEditNameKabinet(EfDatabase.Inventory.Base.Kabinet nameKabinet);

        /// <summary>
        /// Добавление или обновление наименование модели принтера(МФУ)
        /// http://localhost:8182/Inventarka/AddAndEditNameFullModel
        /// </summary>
        /// <param name="nameFullModel"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AddAndEditNameFullModel", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ModelReturn<EfDatabase.Inventory.Base.FullModel> AddAndEditNameFullModel(EfDatabase.Inventory.Base.FullModel nameFullModel);

        /// <summary>
        /// Добавление или обновление наименование классификации принтера(МФУ)
        /// http://localhost:8182/Inventarka/AddAndEditNameClassification
        /// </summary>
        /// <param name="nameClassification"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AddAndEditNameClassification", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ModelReturn<Classification> AddAndEditNameClassification(Classification nameClassification);

        /// <summary> 
        /// Добавление или обновление наименование производителя принтера(МФУ) 
        /// http://localhost:8182/Inventarka/AddAndEditNameFullProizvoditel
        /// </summary>
        /// <param name="nameFullProizvoditel"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AddAndEditNameFullProizvoditel", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ModelReturn<EfDatabase.Inventory.Base.FullProizvoditel> AddAndEditNameFullProizvoditel(EfDatabase.Inventory.Base.FullProizvoditel nameFullProizvoditel);

        /// <summary> 
        /// Добавление или обновление CopySave для МФУ
        /// http://localhost:8182/Inventarka/AddAndEditNameCopySave
        /// </summary>
        /// <param name="nameCopySave"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AddAndEditNameCopySave", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ModelReturn<EfDatabase.Inventory.Base.CopySave> AddAndEditNameCopySave(EfDatabase.Inventory.Base.CopySave nameCopySave);

        /// <summary>
        /// Удаление не актуальных пользователей
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/DeleteUser", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ModelReturn<User> DeleteUser(User user);
        
        /// <summary>
        /// Удаление не актуальных системных блоков
        /// </summary>
        /// <param name="sysBlock">Системный блок</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/DeleteSysBlock", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ModelReturn<SysBlock> DeleteSysBlock(SysBlock sysBlock);
        
        /// <summary>
        /// Удаление не актуальных мониторов
        /// </summary>
        /// <param name="monitor">Монитор</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/DeleteMonitor", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ModelReturn<Monitor> DeleteMonitor(Monitor monitor);

        /// <summary>
        /// Удаление не актуальных Принтеров
        /// </summary>
        /// <param name="printer">Принтер</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/DeletePrinter", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ModelReturn<Printer> DeletePrinter(Printer printer);

        /// <summary>
        /// Удаление не актуальных Сканеров или Камер
        /// </summary>
        /// <param name="scanner">Сканеров или Камера</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/DeleteScannerAndCamera", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ModelReturn<ScanerAndCamer> DeleteScannerAndCamera(ScanerAndCamer scanner);

        /// <summary>
        /// Удаление не актуальных МФУ
        /// </summary>
        /// <param name="mfu">МФУ</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/DeleteMfu", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ModelReturn<EfDatabase.Inventory.Base.Mfu> DeleteMfu(EfDatabase.Inventory.Base.Mfu mfu);

        /// <summary>
        /// Удаление не актуальных ИБП
        /// </summary>
        /// <param name="blockPower">ИБП</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/DeleteBlockPower", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ModelReturn<EfDatabase.Inventory.Base.BlockPower> DeleteBlockPower(EfDatabase.Inventory.Base.BlockPower blockPower);

        /// <summary>
        /// Удаление не актуальных Коммутаторов
        /// </summary>
        /// <param name="switches">Коммутатор</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/DeleteSwitch", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ModelReturn<EfDatabase.Inventory.Base.Swithe> DeleteSwitch(EfDatabase.Inventory.Base.Swithe switches);

        /// <summary>
        /// Удаление не актуальных Телефонов
        /// </summary>
        /// <param name="telephone">Телефон</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/DeleteTelephone", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ModelReturn<EfDatabase.Inventory.Base.Telephon> DeleteTelephone(EfDatabase.Inventory.Base.Telephon telephone);
   }
}
