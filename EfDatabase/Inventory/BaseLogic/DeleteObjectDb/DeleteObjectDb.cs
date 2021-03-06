﻿using System;
using System.Data.Entity;
using System.Linq;
using EfDatabase.Inventory.Base;
using EfDatabase.Inventory.BaseLogic.AddObjectDb;

namespace EfDatabase.Inventory.BaseLogic.DeleteObjectDb
{
    /// <summary>
    /// Класс удаления объектов из БД
    /// </summary>
   public class DeleteObjectDb
    {
        public InventoryContext Inventory { get; set; }

        public DeleteObjectDb()
        {
            Inventory?.Dispose();
            Inventory = new InventoryContext();
        }

        /// <summary>
        /// Удаление пользователя из БД
        /// <param name="user">Пользователь</param>
        /// <param name="idUser">Ун пользователя</param>
        /// </summary>
        public ModelReturn<User> DeleteUser(User user, int? idUser)
        {
            try
            {
                using (var context = new InventoryContext())
                {
                    var isActive = (from users in context.Users
                        where users.IdUser == user.IdUser
                        select users.StatusActual).SingleOrDefault();
                    if (isActive != null && isActive.Value == 2)
                    {
                        var isExistsUsers = context.Database.SqlQuery<object>($"Select * From ErrorUSerNotActul Where IdUser={user.IdUser}");
                        if (isExistsUsers.Any()) return new ModelReturn<User>("Не возможно удалить пользователя! Есть привязки к технике и(или) к Накладной форме!", user,2);
                        DeleteModelDb(context, new User() { IdUser = user.IdUser });
                        Loggers.Log4NetLogger.Info(new Exception("Удалили пользователя "+ user.IdUser));
                        return new ModelReturn<User>("Пользователь удален!", user);
                    }
                    else
                    {
                        return new ModelReturn<User>("Не возможно удалить пользователя! Пользователь не уволен!", user,1);
                    }
                }
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
            }
            return new ModelReturn<User>("При удалении пользователя возникли ошибки " + user.IdUser + " произошла ошибка смотри log.txt", user,3);
        }
        /// <summary>
        /// Удаление системного блока из БД
        /// </summary>
        /// <param name="systemUnit">Системный блок</param>
        /// <param name="idUser">Ун пользователя</param>
        public ModelReturn<SysBlock> DeleteSystemUnit(SysBlock systemUnit, int? idUser)
        {
            try
            {
                using (var context = new InventoryContext())
                {
                    var isExistSystemUnit = context.Database.SqlQuery<object>($"Select * From SysBlock Where IdSysBlock = {systemUnit.IdSysBlock} and IdUser is null and IdStatus is null");
                    if (isExistSystemUnit.Any())
                    {
                        HistoryLog.HistoryLog log = new HistoryLog.HistoryLog();
                        DeleteModelDb(context, new SysBlock() { IdSysBlock = systemUnit.IdSysBlock });
                        log.GenerateHistory(systemUnit.IdHistory, systemUnit.IdSysBlock, "Системный блок", idUser,
                            $"Модель: {systemUnit.NameSysBlock?.NameComputer} Серийный номер: {systemUnit.SerNum} Сервисный номер: {systemUnit.ServiceNum} Инвентарный номер: {systemUnit.InventarNumSysBlok} Имя компьютера: {systemUnit.NameComputer}",
                            "Произведено удаление!");
                        return new ModelReturn<SysBlock>("Системный блок удален!", systemUnit);
                    }
                    return new ModelReturn<SysBlock>("Не возможно удалить системный блок! Есть привязки к пользователю или к статусу!", systemUnit, 1);
                }
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
            }
            return new ModelReturn<SysBlock>("При удалении системного блока возникли ошибки " + systemUnit.IdSysBlock + " произошла ошибка смотри log.txt", systemUnit, 2);
        }

        /// <summary>
        /// Удаление серверного оборудования
        /// </summary>
        /// <param name="serverEquipment">Серверное оборудование</param>
        /// <param name="idUser">Ун пользователя</param>
        public ModelReturn<ServerEquipment> DeleteServerEquipment(ServerEquipment serverEquipment, int? idUser)
        {
            try
            {
                using (var context = new InventoryContext())
                {
                    var isExistSystemUnit = context.Database.SqlQuery<object>($"Select * From ServerEquipment Where Id = {serverEquipment.Id} and IdStatus is null");
                    if (isExistSystemUnit.Any())
                    {
                        HistoryLog.HistoryLog log = new HistoryLog.HistoryLog();
                        DeleteModelDb(context, new ServerEquipment() {Id = serverEquipment.Id});
                        log.GenerateHistory( serverEquipment.IdHistory, serverEquipment.Id, "Серверное оборудование", idUser,
                            $"Модель: {serverEquipment.ModelSeverEquipment?.NameModel} Серийный номер: {serverEquipment.SerNum} Сервисный номер: {serverEquipment.ServiceNum} Инвентарный номер: {serverEquipment.InventarNum}",
                            "Произведено удаление!");
                        return new ModelReturn<ServerEquipment>("Серверное оборудование удалено!", serverEquipment);
                    }
                    return new ModelReturn<ServerEquipment>("Не возможно удалить серверное оборудование! Есть привязки к статусу!", serverEquipment, 1);
                }
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
            }
            return new ModelReturn<ServerEquipment>("При удалении серверного оборудования возникли ошибки " + serverEquipment.Id + " произошла ошибка смотри log.txt", serverEquipment, 2);
        }
        /// <summary>
        /// Удаление монитора из БД
        /// </summary>
        /// <param name="monitor"></param>
        /// <param name="idUser">Ун пользователя</param>
        /// <returns></returns>
        public ModelReturn<Monitor> DeleteMonitor(Monitor monitor, int? idUser)
        {
            try
            {
                using (var context = new InventoryContext())
                {
                    var isExistMonitor = context.Database.SqlQuery<object>($"Select * From Monitors Where IdMonitor = {monitor.IdMonitor} and IdUser is null and IdStatus is null");
                    if (isExistMonitor.Any())
                    {
                        HistoryLog.HistoryLog log = new HistoryLog.HistoryLog();
                        DeleteModelDb(context, new Monitor() { IdMonitor = monitor.IdMonitor });
                        log.GenerateHistory(monitor.IdHistory, monitor.IdMonitor, "Монитор", idUser,
                            $"Модель: {monitor.NameMonitor?.Name} Серийный номер: {monitor.SerNum} Инвентарный номер: {monitor.InventarNumMonitor}",
                            "Произведено удаление!");
                        return new ModelReturn<Monitor>("Монитор удален!", monitor);
                    }
                    return new ModelReturn<Monitor>("Не возможно удалить монитор! Есть привязки к пользователю или к статусу!", monitor, 1);
                }
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
            }
            return new ModelReturn<Monitor>("При удалении монитора возникли ошибки " + monitor.IdMonitor + " произошла ошибка смотри log.txt", monitor, 2);
        }
        /// <summary>
        /// Удаление принтера из БД
        /// </summary>
        /// <param name="printer">Принтер</param>
        /// <param name="idUser">Ун пользователя</param>
        /// <returns></returns>
        public ModelReturn<Printer> DeletePrinter(Printer printer, int? idUser)
        {
            try
            {
                using (var context = new InventoryContext())
                {
                    var isExistPrinter = context.Database.SqlQuery<object>($"Select * From Printer Where IdPrinter = {printer.IdPrinter} and IdUser is null and IdStatus is null");
                    if (isExistPrinter.Any())
                    {
                        HistoryLog.HistoryLog log = new HistoryLog.HistoryLog();
                        DeleteModelDb(context, new Printer() { IdPrinter = printer.IdPrinter });
                        log.GenerateHistory(printer.IdHistory, printer.IdPrinter, "Принтер", idUser,
                            $"Производитель: {printer.FullProizvoditel?.NameProizvoditel} Модель: {printer.FullModel.NameModel} Сервисный номер: {printer.ServiceNumber} Серийный номер: {printer.ZavNumber} Инвентарный номер: {printer.InventarNumber}",
                            "Произведено удаление!");
                        return new ModelReturn<Printer>("Принтер удален!", printer);
                    }
                    return new ModelReturn<Printer>("Не возможно удалить принтер! Есть привязки к пользователю или к статусу!", printer, 1);

                }
            }
            catch (Exception e)
            {
                  Loggers.Log4NetLogger.Error(e);
            }
            return new ModelReturn<Printer>("При удалении принтера возникли ошибки " + printer.IdPrinter + " произошла ошибка смотри log.txt", printer, 2);
        }
        /// <summary>
        /// Удаление сканера или камеры из БД
        /// </summary>
        /// <param name="scanner">Сканер</param>
        /// <param name="idUser">Ун пользователя</param>
        /// <returns></returns>
        public ModelReturn<ScanerAndCamer> DeleteScannerAndCamera(ScanerAndCamer scanner, int? idUser)
        {
            try
            {
                using (var context = new InventoryContext())
                {
                    var isExistScanner = context.Database.SqlQuery<object>($"Select * From ScanerAndCamer Where IdScaner = {scanner.IdScaner} and IdUser is null and IdStatus is null");
                    if (isExistScanner.Any())
                    {
                        HistoryLog.HistoryLog log = new HistoryLog.HistoryLog();
                        DeleteModelDb(context, new ScanerAndCamer() { IdScaner = scanner.IdScaner });
                        log.GenerateHistory(scanner.IdHistory, scanner.IdScaner, "Сканер или камера", idUser,
                            $"Производитель: {scanner.FullProizvoditel?.NameProizvoditel} Модель: {scanner.FullModel.NameModel} Сервисный номер: {scanner.ServiceNumber} Серийный номер: {scanner.ZavNumber} Инвентарный номер: {scanner.InventarNumber}",
                            "Произведено удаление!");
                        return new ModelReturn<ScanerAndCamer>("Сканер или камера удалена!", scanner);
                    }
                    return new ModelReturn<ScanerAndCamer>("Не возможно удалить сканер или камеру! Есть привязки к пользователю или к статусу!", scanner, 1);
                }
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
            }
            return new ModelReturn<ScanerAndCamer>("При удалении сканера или камеры возникли ошибки " + scanner.IdScaner + " произошла ошибка смотри log.txt", scanner, 2);
        }
        /// <summary>
        /// Удаление МФУ из БД
        /// </summary>
        /// <param name="mfu">МФУ</param>
        /// <param name="idUser">Ун пользователя</param>
        /// <returns></returns>
        public ModelReturn<Mfu> DeleteMfu(Mfu mfu, int? idUser)
        {
            try
            {
                using (var context = new InventoryContext())
                {
                    var isExistMfu = context.Database.SqlQuery<object>($"Select * From Mfu Where IdMfu = {mfu.IdMfu} and IdUser is null and IdStatus is null");
                    if (isExistMfu.Any())
                    {
                        HistoryLog.HistoryLog log = new HistoryLog.HistoryLog();
                        DeleteModelDb(context, new Mfu() { IdMfu = mfu.IdMfu });
                        log.GenerateHistory(mfu.IdHistory, mfu.IdMfu, "МФУ", idUser,
                            $"Производитель: {mfu.FullProizvoditel?.NameProizvoditel} Модель: {mfu.FullModel.NameModel} Сервисный номер: {mfu.ServiceNumber} Серийный номер: {mfu.ZavNumber} Инвентарный номер: {mfu.InventarNumber}",
                            "Произведено удаление!");
                        return new ModelReturn<Mfu>("МФУ удален!", mfu);
                    }
                    return new ModelReturn<Mfu>("Не возможно удалить МФУ! Есть привязки к пользователю или к статусу!", mfu, 1);
                }
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
            }
            return new ModelReturn<Mfu>("При удалении МФУ возникли ошибки " + mfu.IdMfu + " произошла ошибка смотри log.txt", mfu, 2);
        }
        /// <summary>
        /// Удаление ИБП 
        /// </summary>
        /// <param name="blockPower">ИБП</param>
        /// <param name="idUser">Ун пользователя</param>
        /// <returns></returns>
        public ModelReturn<BlockPower> DeleteBlockPower(BlockPower blockPower, int? idUser)
        {
            try
            {
                using (var context = new InventoryContext())
                {
                    var isExistBlockPower = context.Database.SqlQuery<object>($"Select * From BlockPower Where IdBlockPowers = {blockPower.IdBlockPowers} and IdUser is null and IdStatus is null");
                    if (isExistBlockPower.Any())
                    {
                        HistoryLog.HistoryLog log = new HistoryLog.HistoryLog();
                        DeleteModelDb(context, new BlockPower() { IdBlockPowers = blockPower.IdBlockPowers });
                        log.GenerateHistory(blockPower.IdHistory, blockPower.IdBlockPowers, "ИБП", idUser,
                            $"Производитель: {blockPower.ProizvoditelBlockPower.Name} Модель: {blockPower.ModelBlockPower.Name} Сервисный номер: {blockPower.ServiceNumber} Серийный номер: {blockPower.ZavNumber} Инвентарный номер: {blockPower.InventarNumber}",
                            "Произведено удаление!");
                        return new ModelReturn<BlockPower>("ИБП удален!", blockPower);
                    }
                    return new ModelReturn<BlockPower>("Не возможно удалить ИБП! Есть привязки к пользователю или к статусу!", blockPower, 1);
                }
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
            }
            return new ModelReturn<BlockPower>("При удалении ИБП возникли ошибки " + blockPower.IdBlockPowers + " произошла ошибка смотри log.txt", blockPower, 2);
        }
        /// <summary>
        /// Удаление коммутатора
        /// </summary>
        /// <param name="switches">Коммутатор</param>
        /// <param name="idUser">Ун пользователя</param>
        /// <returns></returns>
        public ModelReturn<Swithe> DeleteSwitch(Swithe switches, int? idUser)
        {
            try
            {
                using (var context = new InventoryContext())
                {
                    var isExistSwitch = context.Database.SqlQuery<object>($"Select * From Swithes Where IdSwithes = {switches.IdSwithes} and IdUser is null and IdStatus is null");
                    if (isExistSwitch.Any())
                    {
                        HistoryLog.HistoryLog log = new HistoryLog.HistoryLog();
                        DeleteModelDb(context, new Swithe() { IdSwithes = switches.IdSwithes });
                        log.GenerateHistory(switches.IdHistory, switches.IdSwithes, "Коммутатор", idUser,
                            $"Модель: {switches.ModelSwithe?.NameModel} Сервисный номер: {switches.ServiceNum} Серийный номер: {switches.SerNum} Инвентарный номер: {switches.InventarNum}",
                            "Произведено удаление!");
                        return new ModelReturn<Swithe>("Коммутатор удален!", switches);
                    }
                    return new ModelReturn<Swithe>("Не возможно удалить коммутатор! Есть привязки к пользователю или к статусу!", switches, 1);
                }
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
            }
            return new ModelReturn<Swithe>("При удалении Коммутатора возникли ошибки " + switches.IdSwithes + " произошла ошибка смотри log.txt", switches, 2);
        }
        /// <summary>
        /// Удаление телефона
        /// </summary>
        /// <param name="telephone">Телефон</param>
        /// <param name="idUser">Ун пользователя</param>
        /// <returns></returns>
        public ModelReturn<Telephon> DeleteTelephone(Telephon telephone, int? idUser)
        {
            try
            {
                using (var context = new InventoryContext())
                {
                    var isExistTelephone = context.Database.SqlQuery<object>($@"Select * From Telephon
                                                                                               Left Join Users on Users.IdTelephon = Telephon.IdTelephon
                                                                                               Left Join Statusing on Statusing.IdStatus = Telephon.IdStatus
                                                                                               Where Telephon.IdTelephon = {telephone.IdTelephon} and Users.IdUser is null  and  Telephon.IdStatus is null");
                    if (isExistTelephone.Any())
                    {
                        HistoryLog.HistoryLog log = new HistoryLog.HistoryLog();
                        DeleteModelDb(context, new Telephon() { IdTelephon = telephone.IdTelephon });
                        log.GenerateHistory(null, telephone.IdTelephon, "Телефон", idUser,
                            $"Модель: {telephone.NameTelephone} Серийный номер: {telephone.SerNumber} Мак адрес: {telephone.MacTelephon}",
                            "Произведено удаление!");
                        return new ModelReturn<Telephon>("Телефон удален!", telephone);
                    }
                    return new ModelReturn<Telephon>("Не возможно удалить телефон! Есть привязки к пользователю или к статусу!", telephone, 1);
                }
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
            }
            return new ModelReturn<Telephon>("При удалении Телефона возникли ошибки " + telephone.IdTelephon + " произошла ошибка смотри log.txt", telephone, 2);
        }

        /// <summary>
        /// Общее удаление моделек
        /// </summary>
        /// <typeparam name="T">Тип явный не явный моделей БД</typeparam>
        /// <param name="context">Контекст с БД</param>
        /// <param name="modelDelete">Модель для удаления</param>
        private void DeleteModelDb<T>(InventoryContext context, T modelDelete)
        {
            context.Entry(modelDelete).State = EntityState.Deleted;
            context.SaveChanges();
        }
    }
}
