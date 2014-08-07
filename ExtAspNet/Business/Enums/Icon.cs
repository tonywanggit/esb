
#region Comment

/*
 * Project:     ExtAspNet
 * 
 * FileName:    IconType.cs
 * CreatedOn:   2009-09-18
 * CreatedBy:   sanshi.ustc@gmail.com
 * 
 * 
 * Description：
 *      ->
 *   
 * History：
 *      ->
 * 
 * 
 * 
 * 
 */

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;

namespace ExtAspNet
{
    /// <summary>
    /// 预定义图标
    /// </summary>
    public enum Icon
    {
        None,
        Accept,
        Add,
        Anchor,
        Application,
        ApplicationAdd,
        ApplicationCascade,
        ApplicationDelete,
        ApplicationDouble,
        ApplicationEdit,
        ApplicationError,
        ApplicationForm,
        ApplicationFormAdd,
        ApplicationFormDelete,
        ApplicationFormEdit,
        ApplicationFormMagnify,
        ApplicationGet,
        ApplicationGo,
        ApplicationHome,
        ApplicationKey,
        ApplicationLightning,
        ApplicationLink,
        ApplicationOsx,
        ApplicationOsxAdd,
        ApplicationOsxCascade,
        ApplicationOsxDelete,
        ApplicationOsxDouble,
        ApplicationOsxError,
        ApplicationOsxGet,
        ApplicationOsxGo,
        ApplicationOsxHome,
        ApplicationOsxKey,
        ApplicationOsxLightning,
        ApplicationOsxLink,
        ApplicationOsxSplit,
        ApplicationOsxStart,
        ApplicationOsxStop,
        ApplicationOsxTerminal,
        ApplicationPut,
        ApplicationSideBoxes,
        ApplicationSideContract,
        ApplicationSideExpand,
        ApplicationSideList,
        ApplicationSideTree,
        ApplicationSplit,
        ApplicationStart,
        ApplicationStop,
        ApplicationTileHorizontal,
        ApplicationTileVertical,
        ApplicationViewColumns,
        ApplicationViewDetail,
        ApplicationViewGallery,
        ApplicationViewIcons,
        ApplicationViewList,
        ApplicationViewTile,
        ApplicationXp,
        ApplicationXpTerminal,
        ArrowBranch,
        ArrowDivide,
        ArrowDown,
        ArrowEw,
        ArrowIn,
        ArrowInout,
        ArrowInLonger,
        ArrowJoin,
        ArrowLeft,
        ArrowMerge,
        ArrowNe,
        ArrowNs,
        ArrowNsew,
        ArrowNw,
        ArrowNwNeSwSe,
        ArrowNwSe,
        ArrowOut,
        ArrowOutLonger,
        ArrowRedo,
        ArrowRefresh,
        ArrowRefreshSmall,
        ArrowRight,
        ArrowRotateAnticlockwise,
        ArrowRotateClockwise,
        ArrowSe,
        ArrowSw,
        ArrowSwitch,
        ArrowSwitchBluegreen,
        ArrowSwNe,
        ArrowTurnLeft,
        ArrowTurnRight,
        ArrowUndo,
        ArrowUp,
        AsteriskOrange,
        AsteriskRed,
        AsteriskYellow,
        Attach,
        AwardStarAdd,
        AwardStarBronze1,
        AwardStarBronze2,
        AwardStarBronze3,
        AwardStarDelete,
        AwardStarGold1,
        AwardStarGold2,
        AwardStarGold3,
        AwardStarSilver1,
        AwardStarSilver2,
        AwardStarSilver3,
        Basket,
        BasketAdd,
        BasketDelete,
        BasketEdit,
        BasketError,
        BasketGo,
        BasketPut,
        BasketRemove,
        Bell,
        BellAdd,
        BellDelete,
        BellError,
        BellGo,
        BellLink,
        BellSilver,
        BellSilverStart,
        BellSilverStop,
        BellStart,
        BellStop,
        Bin,
        BinClosed,
        BinEmpty,
        Blank,
        Bomb,
        Book,
        Bookmark,
        BookmarkAdd,
        BookmarkDelete,
        BookmarkEdit,
        BookmarkError,
        BookmarkGo,
        BookAdd,
        BookAddresses,
        BookAddressesAdd,
        BookAddressesDelete,
        BookAddressesEdit,
        BookAddressesError,
        BookAddressesKey,
        BookDelete,
        BookEdit,
        BookError,
        BookGo,
        BookKey,
        BookLink,
        BookMagnify,
        BookNext,
        BookOpen,
        BookOpenMark,
        BookPrevious,
        BookRed,
        BookTabs,
        BorderAll,
        BorderBottom,
        BorderDraw,
        BorderInner,
        BorderInnerHorizontal,
        BorderInnerVertical,
        BorderLeft,
        BorderNone,
        BorderOuter,
        BorderRight,
        BorderTop,
        Box,
        BoxError,
        BoxPicture,
        BoxWorld,
        Brick,
        Bricks,
        BrickAdd,
        BrickDelete,
        BrickEdit,
        BrickError,
        BrickGo,
        BrickLink,
        BrickMagnify,
        Briefcase,
        Bug,
        BugAdd,
        BugDelete,
        BugEdit,
        BugError,
        BugFix,
        BugGo,
        BugLink,
        BugMagnify,
        Build,
        Building,
        BuildingAdd,
        BuildingDelete,
        BuildingEdit,
        BuildingError,
        BuildingGo,
        BuildingKey,
        BuildingLink,
        BuildCancel,
        BulletAdd,
        BulletArrowBottom,
        BulletArrowDown,
        BulletArrowTop,
        BulletArrowUp,
        BulletBlack,
        BulletBlue,
        BulletConnect,
        BulletCross,
        BulletDatabase,
        BulletDatabaseYellow,
        BulletDelete,
        BulletDisk,
        BulletEarth,
        BulletEdit,
        BulletEject,
        BulletError,
        BulletFeed,
        BulletGet,
        BulletGo,
        BulletGreen,
        BulletHome,
        BulletKey,
        BulletLeft,
        BulletLightning,
        BulletMagnify,
        BulletMinus,
        BulletOrange,
        BulletPageWhite,
        BulletPicture,
        BulletPink,
        BulletPlus,
        BulletPurple,
        BulletRed,
        BulletRight,
        BulletShape,
        BulletSparkle,
        BulletStar,
        BulletStart,
        BulletStop,
        BulletStopAlt,
        BulletTick,
        BulletToggleMinus,
        BulletTogglePlus,
        BulletWhite,
        BulletWrench,
        BulletWrenchRed,
        BulletYellow,
        Button,
        Cake,
        CakeOut,
        CakeSliced,
        Calculator,
        CalculatorAdd,
        CalculatorDelete,
        CalculatorEdit,
        CalculatorError,
        CalculatorLink,
        Calendar,
        CalendarAdd,
        CalendarDelete,
        CalendarEdit,
        CalendarLink,
        CalendarSelectDay,
        CalendarSelectNone,
        CalendarSelectWeek,
        CalendarStar,
        CalendarViewDay,
        CalendarViewMonth,
        CalendarViewWeek,
        Camera,
        CameraAdd,
        CameraConnect,
        CameraDelete,
        CameraEdit,
        CameraError,
        CameraGo,
        CameraLink,
        CameraMagnify,
        CameraPicture,
        CameraSmall,
        CameraStart,
        CameraStop,
        Cancel,
        Car,
        Cart,
        CartAdd,
        CartDelete,
        CartEdit,
        CartError,
        CartFull,
        CartGo,
        CartMagnify,
        CartPut,
        CartRemove,
        CarAdd,
        CarDelete,
        CarError,
        CarRed,
        CarStart,
        CarStop,
        Cd,
        Cdr,
        CdrAdd,
        CdrBurn,
        CdrCross,
        CdrDelete,
        CdrEdit,
        CdrEject,
        CdrError,
        CdrGo,
        CdrMagnify,
        CdrPlay,
        CdrStart,
        CdrStop,
        CdrStopAlt,
        CdrTick,
        CdAdd,
        CdBurn,
        CdDelete,
        CdEdit,
        CdEject,
        CdGo,
        CdMagnify,
        CdPlay,
        CdStop,
        CdStopAlt,
        CdTick,
        ChartBar,
        ChartBarAdd,
        ChartBarDelete,
        ChartBarEdit,
        ChartBarError,
        ChartBarLink,
        ChartCurve,
        ChartCurveAdd,
        ChartCurveDelete,
        ChartCurveEdit,
        ChartCurveError,
        ChartCurveGo,
        ChartCurveLink,
        ChartLine,
        ChartLineAdd,
        ChartLineDelete,
        ChartLineEdit,
        ChartLineError,
        ChartLineLink,
        ChartOrganisation,
        ChartOrganisationAdd,
        ChartOrganisationDelete,
        ChartOrgInverted,
        ChartPie,
        ChartPieAdd,
        ChartPieDelete,
        ChartPieEdit,
        ChartPieError,
        ChartPieLightning,
        ChartPieLink,
        CheckError,
        Clipboard,
        Clock,
        ClockAdd,
        ClockDelete,
        ClockEdit,
        ClockError,
        ClockGo,
        ClockLink,
        ClockPause,
        ClockPlay,
        ClockRed,
        ClockStart,
        ClockStop,
        ClockStop2,
        Cmy,
        Cog,
        CogAdd,
        CogDelete,
        CogEdit,
        CogError,
        CogGo,
        CogStart,
        CogStop,
        Coins,
        CoinsAdd,
        CoinsDelete,
        Color,
        ColorSwatch,
        ColorWheel,
        Comment,
        Comments,
        CommentsAdd,
        CommentsDelete,
        CommentAdd,
        CommentDelete,
        CommentDull,
        CommentEdit,
        CommentPlay,
        CommentRecord,
        Compass,
        Compress,
        Computer,
        ComputerAdd,
        ComputerConnect,
        ComputerDelete,
        ComputerEdit,
        ComputerError,
        ComputerGo,
        ComputerKey,
        ComputerLink,
        ComputerMagnify,
        ComputerOff,
        ComputerStart,
        ComputerStop,
        ComputerWrench,
        Connect,
        Contrast,
        ContrastDecrease,
        ContrastHigh,
        ContrastIncrease,
        ContrastLow,
        Controller,
        ControllerAdd,
        ControllerDelete,
        ControllerError,
        ControlAdd,
        ControlAddBlue,
        ControlBlank,
        ControlBlankBlue,
        ControlEject,
        ControlEjectBlue,
        ControlEnd,
        ControlEndBlue,
        ControlEqualizer,
        ControlEqualizerBlue,
        ControlFastforward,
        ControlFastforwardBlue,
        ControlPause,
        ControlPauseBlue,
        ControlPlay,
        ControlPlayBlue,
        ControlPower,
        ControlPowerBlue,
        ControlRecord,
        ControlRecordBlue,
        ControlRemove,
        ControlRemoveBlue,
        ControlRepeat,
        ControlRepeatBlue,
        ControlRewind,
        ControlRewindBlue,
        ControlStart,
        ControlStartBlue,
        ControlStop,
        ControlStopBlue,
        Creditcards,
        Cross,
        Css,
        CssAdd,
        CssDelete,
        CssError,
        CssGo,
        CssValid,
        Cup,
        CupAdd,
        CupBlack,
        CupDelete,
        CupEdit,
        CupError,
        CupGo,
        CupGreen,
        CupKey,
        CupLink,
        CupTea,
        Cursor,
        CursorSmall,
        Cut,
        CutRed,
        Database,
        DatabaseAdd,
        DatabaseConnect,
        DatabaseCopy,
        DatabaseDelete,
        DatabaseEdit,
        DatabaseError,
        DatabaseGear,
        DatabaseGo,
        DatabaseKey,
        DatabaseLightning,
        DatabaseLink,
        DatabaseRefresh,
        DatabaseSave,
        DatabaseStart,
        DatabaseStop,
        DatabaseTable,
        DatabaseWrench,
        DatabaseYellow,
        DatabaseYellowStart,
        DatabaseYellowStop,
        Date,
        DateAdd,
        DateDelete,
        DateEdit,
        DateError,
        DateGo,
        DateLink,
        DateMagnify,
        DateNext,
        DatePrevious,
        Decline,
        Delete,
        DeviceStylus,
        Disconnect,
        Disk,
        DiskBlack,
        DiskBlackError,
        DiskBlackMagnify,
        DiskDownload,
        DiskEdit,
        DiskError,
        DiskMagnify,
        DiskMultiple,
        DiskUpload,
        Door,
        DoorError,
        DoorIn,
        DoorOpen,
        DoorOut,
        Drink,
        DrinkEmpty,
        DrinkRed,
        Drive,
        DriveAdd,
        DriveBurn,
        DriveCd,
        DriveCdr,
        DriveCdEmpty,
        DriveDelete,
        DriveDisk,
        DriveEdit,
        DriveError,
        DriveGo,
        DriveKey,
        DriveLink,
        DriveMagnify,
        DriveNetwork,
        DriveNetworkError,
        DriveNetworkStop,
        DriveRename,
        DriveUser,
        DriveWeb,
        Dvd,
        DvdAdd,
        DvdDelete,
        DvdEdit,
        DvdError,
        DvdGo,
        DvdKey,
        DvdLink,
        DvdStart,
        DvdStop,
        EjectBlue,
        EjectGreen,
        Email,
        EmailAdd,
        EmailAttach,
        EmailDelete,
        EmailEdit,
        EmailError,
        EmailGo,
        EmailLink,
        EmailMagnify,
        EmailOpen,
        EmailOpenImage,
        EmailStar,
        EmailStart,
        EmailStop,
        EmailTransfer,
        EmoticonEvilgrin,
        EmoticonGrin,
        EmoticonHappy,
        EmoticonSmile,
        EmoticonSurprised,
        EmoticonTongue,
        EmoticonUnhappy,
        EmoticonWaii,
        EmoticonWink,
        Erase,
        Error,
        ErrorAdd,
        ErrorDelete,
        ErrorGo,
        Exclamation,
        Eye,
        Eyes,
        Feed,
        FeedAdd,
        FeedDelete,
        FeedDisk,
        FeedEdit,
        FeedError,
        FeedGo,
        FeedKey,
        FeedLink,
        FeedMagnify,
        FeedStar,
        Female,
        Film,
        FilmAdd,
        FilmDelete,
        FilmEdit,
        FilmEject,
        FilmError,
        FilmGo,
        FilmKey,
        FilmLink,
        FilmMagnify,
        FilmSave,
        FilmStar,
        FilmStart,
        FilmStop,
        Find,
        FingerPoint,
        FlagAd,
        FlagAe,
        FlagAf,
        FlagAg,
        FlagAi,
        FlagAl,
        FlagAm,
        FlagAn,
        FlagAo,
        FlagAr,
        FlagAs,
        FlagAt,
        FlagAu,
        FlagAw,
        FlagAx,
        FlagAz,
        FlagBa,
        FlagBb,
        FlagBd,
        FlagBe,
        FlagBf,
        FlagBg,
        FlagBh,
        FlagBi,
        FlagBj,
        FlagBlack,
        FlagBlue,
        FlagBm,
        FlagBn,
        FlagBo,
        FlagBr,
        FlagBs,
        FlagBt,
        FlagBv,
        FlagBw,
        FlagBy,
        FlagBz,
        FlagCa,
        FlagCatalonia,
        FlagCc,
        FlagCd,
        FlagCf,
        FlagCg,
        FlagCh,
        FlagChecked,
        FlagCi,
        FlagCk,
        FlagCl,
        FlagCm,
        FlagCn,
        FlagCo,
        FlagCr,
        FlagCs,
        FlagCu,
        FlagCv,
        FlagCx,
        FlagCy,
        FlagCz,
        FlagDe,
        FlagDj,
        FlagDk,
        FlagDm,
        FlagDo,
        FlagDz,
        FlagEc,
        FlagEe,
        FlagEg,
        FlagEh,
        FlagEngland,
        FlagEr,
        FlagEs,
        FlagEt,
        FlagEuropeanunion,
        FlagFam,
        FlagFi,
        FlagFj,
        FlagFk,
        FlagFm,
        FlagFo,
        FlagFr,
        FlagFrance,
        FlagGa,
        FlagGb,
        FlagGd,
        FlagGe,
        FlagGf,
        FlagGg,
        FlagGh,
        FlagGi,
        FlagGl,
        FlagGm,
        FlagGn,
        FlagGp,
        FlagGq,
        FlagGr,
        FlagGreen,
        FlagGrey,
        FlagGs,
        FlagGt,
        FlagGu,
        FlagGw,
        FlagGy,
        FlagHk,
        FlagHm,
        FlagHn,
        FlagHr,
        FlagHt,
        FlagHu,
        FlagId,
        FlagIe,
        FlagIl,
        FlagIn,
        FlagIo,
        FlagIq,
        FlagIr,
        FlagIs,
        FlagIt,
        FlagJm,
        FlagJo,
        FlagJp,
        FlagKe,
        FlagKg,
        FlagKh,
        FlagKi,
        FlagKm,
        FlagKn,
        FlagKp,
        FlagKr,
        FlagKw,
        FlagKy,
        FlagKz,
        FlagLa,
        FlagLb,
        FlagLc,
        FlagLi,
        FlagLk,
        FlagLr,
        FlagLs,
        FlagLt,
        FlagLu,
        FlagLv,
        FlagLy,
        FlagMa,
        FlagMc,
        FlagMd,
        FlagMe,
        FlagMg,
        FlagMh,
        FlagMk,
        FlagMl,
        FlagMm,
        FlagMn,
        FlagMo,
        FlagMp,
        FlagMq,
        FlagMr,
        FlagMs,
        FlagMt,
        FlagMu,
        FlagMv,
        FlagMw,
        FlagMx,
        FlagMy,
        FlagMz,
        FlagNa,
        FlagNc,
        FlagNe,
        FlagNf,
        FlagNg,
        FlagNi,
        FlagNl,
        FlagNo,
        FlagNp,
        FlagNr,
        FlagNu,
        FlagNz,
        FlagOm,
        FlagOrange,
        FlagPa,
        FlagPe,
        FlagPf,
        FlagPg,
        FlagPh,
        FlagPink,
        FlagPk,
        FlagPl,
        FlagPm,
        FlagPn,
        FlagPr,
        FlagPs,
        FlagPt,
        FlagPurple,
        FlagPw,
        FlagPy,
        FlagQa,
        FlagRe,
        FlagRed,
        FlagRo,
        FlagRs,
        FlagRu,
        FlagRw,
        FlagSa,
        FlagSb,
        FlagSc,
        FlagScotland,
        FlagSd,
        FlagSe,
        FlagSg,
        FlagSh,
        FlagSi,
        FlagSj,
        FlagSk,
        FlagSl,
        FlagSm,
        FlagSn,
        FlagSo,
        FlagSr,
        FlagSt,
        FlagSv,
        FlagSy,
        FlagSz,
        FlagTc,
        FlagTd,
        FlagTf,
        FlagTg,
        FlagTh,
        FlagTj,
        FlagTk,
        FlagTl,
        FlagTm,
        FlagTn,
        FlagTo,
        FlagTr,
        FlagTt,
        FlagTv,
        FlagTw,
        FlagTz,
        FlagUa,
        FlagUg,
        FlagUm,
        FlagUs,
        FlagUy,
        FlagUz,
        FlagVa,
        FlagVc,
        FlagVe,
        FlagVg,
        FlagVi,
        FlagVn,
        FlagVu,
        FlagWales,
        FlagWf,
        FlagWhite,
        FlagWs,
        FlagYe,
        FlagYellow,
        FlagYt,
        FlagZa,
        FlagZm,
        FlagZw,
        FlowerDaisy,
        Folder,
        FolderAdd,
        FolderBell,
        FolderBookmark,
        FolderBrick,
        FolderBug,
        FolderCamera,
        FolderConnect,
        FolderDatabase,
        FolderDelete,
        FolderEdit,
        FolderError,
        FolderExplore,
        FolderFeed,
        FolderFilm,
        FolderFind,
        FolderFont,
        FolderGo,
        FolderHeart,
        FolderHome,
        FolderImage,
        FolderKey,
        FolderLightbulb,
        FolderLink,
        FolderMagnify,
        FolderPage,
        FolderPageWhite,
        FolderPalette,
        FolderPicture,
        FolderStar,
        FolderTable,
        FolderUp,
        FolderUser,
        FolderWrench,
        Font,
        FontAdd,
        FontColor,
        FontDelete,
        FontGo,
        FontLarger,
        FontSmaller,
        ForwardBlue,
        ForwardGreen,
        Group,
        GroupAdd,
        GroupDelete,
        GroupEdit,
        GroupError,
        GroupGear,
        GroupGo,
        GroupKey,
        GroupLink,
        Heart,
        HeartAdd,
        HeartBroken,
        HeartConnect,
        HeartDelete,
        Help,
        Hourglass,
        HourglassAdd,
        HourglassDelete,
        HourglassGo,
        HourglassLink,
        House,
        HouseConnect,
        HouseGo,
        HouseKey,
        HouseLink,
        HouseStar,
        Html,
        HtmlAdd,
        HtmlDelete,
        HtmlError,
        HtmlGo,
        HtmlValid,
        Image,
        Images,
        ImageAdd,
        ImageDelete,
        ImageEdit,
        ImageLink,
        ImageMagnify,
        ImageStar,
        Information,
        Ipod,
        IpodCast,
        IpodCastAdd,
        IpodCastDelete,
        IpodConnect,
        IpodNano,
        IpodNanoConnect,
        IpodSound,
        Joystick,
        JoystickAdd,
        JoystickConnect,
        JoystickDelete,
        JoystickError,
        Key,
        Keyboard,
        KeyboardAdd,
        KeyboardConnect,
        KeyboardDelete,
        KeyboardMagnify,
        KeyAdd,
        KeyDelete,
        KeyGo,
        KeyStart,
        KeyStop,
        Laptop,
        LaptopAdd,
        LaptopConnect,
        LaptopDelete,
        LaptopDisk,
        LaptopEdit,
        LaptopError,
        LaptopGo,
        LaptopKey,
        LaptopLink,
        LaptopMagnify,
        LaptopStart,
        LaptopStop,
        LaptopWrench,
        Layers,
        Layout,
        LayoutAdd,
        LayoutContent,
        LayoutDelete,
        LayoutEdit,
        LayoutError,
        LayoutHeader,
        LayoutKey,
        LayoutLightning,
        LayoutLink,
        LayoutSidebar,
        Lightbulb,
        LightbulbAdd,
        LightbulbDelete,
        LightbulbOff,
        Lightning,
        LightningAdd,
        LightningDelete,
        LightningGo,
        Link,
        LinkAdd,
        LinkBreak,
        LinkDelete,
        LinkEdit,
        LinkError,
        LinkGo,
        Lock,
        LockAdd,
        LockBreak,
        LockDelete,
        LockEdit,
        LockGo,
        LockKey,
        LockOpen,
        LockStart,
        LockStop,
        Lorry,
        LorryAdd,
        LorryDelete,
        LorryError,
        LorryFlatbed,
        LorryGo,
        LorryLink,
        LorryStart,
        LorryStop,
        MagifierZoomOut,
        Magnifier,
        MagnifierZoomIn,
        Mail,
        Male,
        Map,
        MapAdd,
        MapClipboard,
        MapCursor,
        MapDelete,
        MapEdit,
        MapError,
        MapGo,
        MapLink,
        MapMagnify,
        MapStart,
        MapStop,
        MedalBronze1,
        MedalBronze2,
        MedalBronze3,
        MedalBronzeAdd,
        MedalBronzeDelete,
        MedalGold1,
        MedalGold2,
        MedalGold3,
        MedalGoldAdd,
        MedalGoldDelete,
        MedalSilver1,
        MedalSilver2,
        MedalSilver3,
        MedalSilverAdd,
        MedalSilverDelete,
        Money,
        MoneyAdd,
        MoneyDelete,
        MoneyDollar,
        MoneyEuro,
        MoneyPound,
        MoneyYen,
        Monitor,
        MonitorAdd,
        MonitorDelete,
        MonitorEdit,
        MonitorError,
        MonitorGo,
        MonitorKey,
        MonitorLightning,
        MonitorLink,
        MoonFull,
        Mouse,
        MouseAdd,
        MouseDelete,
        MouseError,
        Music,
        MusicNote,
        Neighbourhood,
        New,
        Newspaper,
        NewspaperAdd,
        NewspaperDelete,
        NewspaperGo,
        NewspaperLink,
        NewBlue,
        NewRed,
        NextBlue,
        NextGreen,
        Note,
        NoteAdd,
        NoteDelete,
        NoteEdit,
        NoteError,
        NoteGo,
        Outline,
        Overlays,
        Package,
        PackageAdd,
        PackageDelete,
        PackageDown,
        PackageGo,
        PackageGreen,
        PackageIn,
        PackageLink,
        PackageSe,
        PackageStart,
        PackageStop,
        PackageWhite,
        Page,
        PageAdd,
        PageAttach,
        PageBack,
        PageBreak,
        PageBreakInsert,
        PageCancel,
        PageCode,
        PageCopy,
        PageDelete,
        PageEdit,
        PageError,
        PageExcel,
        PageFind,
        PageForward,
        PageGear,
        PageGo,
        PageGreen,
        PageHeaderFooter,
        PageKey,
        PageLandscape,
        PageLandscapeShot,
        PageLightning,
        PageLink,
        PageMagnify,
        PagePaintbrush,
        PagePaste,
        PagePortrait,
        PagePortraitShot,
        PageRed,
        PageRefresh,
        PageSave,
        PageWhite,
        PageWhiteAcrobat,
        PageWhiteActionscript,
        PageWhiteAdd,
        PageWhiteBreak,
        PageWhiteC,
        PageWhiteCamera,
        PageWhiteCd,
        PageWhiteCdr,
        PageWhiteCode,
        PageWhiteCodeRed,
        PageWhiteColdfusion,
        PageWhiteCompressed,
        PageWhiteConnect,
        PageWhiteCopy,
        PageWhiteCplusplus,
        PageWhiteCsharp,
        PageWhiteCup,
        PageWhiteDatabase,
        PageWhiteDatabaseYellow,
        PageWhiteDelete,
        PageWhiteDvd,
        PageWhiteEdit,
        PageWhiteError,
        PageWhiteExcel,
        PageWhiteFind,
        PageWhiteFlash,
        PageWhiteFont,
        PageWhiteFreehand,
        PageWhiteGear,
        PageWhiteGet,
        PageWhiteGo,
        PageWhiteH,
        PageWhiteHorizontal,
        PageWhiteKey,
        PageWhiteLightning,
        PageWhiteLink,
        PageWhiteMagnify,
        PageWhiteMedal,
        PageWhiteOffice,
        PageWhitePaint,
        PageWhitePaintbrush,
        PageWhitePaint2,
        PageWhitePaste,
        PageWhitePasteTable,
        PageWhitePhp,
        PageWhitePicture,
        PageWhitePowerpoint,
        PageWhitePut,
        PageWhiteRefresh,
        PageWhiteRuby,
        PageWhiteSideBySide,
        PageWhiteStack,
        PageWhiteStar,
        PageWhiteSwoosh,
        PageWhiteText,
        PageWhiteTextWidth,
        PageWhiteTux,
        PageWhiteVector,
        PageWhiteVisualstudio,
        PageWhiteWidth,
        PageWhiteWord,
        PageWhiteWorld,
        PageWhiteWrench,
        PageWhiteZip,
        PageWord,
        PageWorld,
        Paint,
        Paintbrush,
        PaintbrushColor,
        Paintcan,
        PaintcanRed,
        PaintCanBrush,
        Palette,
        PastePlain,
        PasteWord,
        PauseBlue,
        PauseGreen,
        PauseRecord,
        Pencil,
        PencilAdd,
        PencilDelete,
        PencilGo,
        Phone,
        PhoneAdd,
        PhoneDelete,
        PhoneEdit,
        PhoneError,
        PhoneGo,
        PhoneKey,
        PhoneLink,
        PhoneSound,
        PhoneStart,
        PhoneStop,
        Photo,
        Photos,
        PhotoAdd,
        PhotoDelete,
        PhotoEdit,
        PhotoLink,
        PhotoPaint,
        Picture,
        Pictures,
        PicturesThumbs,
        PictureAdd,
        PictureClipboard,
        PictureDelete,
        PictureEdit,
        PictureEmpty,
        PictureError,
        PictureGo,
        PictureKey,
        PictureLink,
        PictureSave,
        Pilcrow,
        Pill,
        PillAdd,
        PillDelete,
        PillError,
        PillGo,
        PlayBlue,
        PlayGreen,
        Plugin,
        PluginAdd,
        PluginDelete,
        PluginDisabled,
        PluginEdit,
        PluginError,
        PluginGo,
        PluginKey,
        PluginLink,
        PreviousGreen,
        Printer,
        PrinterAdd,
        PrinterCancel,
        PrinterColor,
        PrinterConnect,
        PrinterDelete,
        PrinterEmpty,
        PrinterError,
        PrinterGo,
        PrinterKey,
        PrinterMono,
        PrinterStart,
        PrinterStop,
        Rainbow,
        RainbowStar,
        RecordBlue,
        RecordGreen,
        RecordRed,
        Reload,
        Report,
        ReportAdd,
        ReportDelete,
        ReportDisk,
        ReportEdit,
        ReportGo,
        ReportKey,
        ReportLink,
        ReportMagnify,
        ReportPicture,
        ReportStart,
        ReportStop,
        ReportUser,
        ReportWord,
        ResultsetFirst,
        ResultsetLast,
        ResultsetNext,
        ResultsetPrevious,
        ReverseBlue,
        ReverseGreen,
        RewindBlue,
        RewindGreen,
        Rgb,
        Rosette,
        RosetteBlue,
        Rss,
        RssAdd,
        RssDelete,
        RssError,
        RssGo,
        RssValid,
        Ruby,
        RubyAdd,
        RubyDelete,
        RubyGear,
        RubyGet,
        RubyGo,
        RubyKey,
        RubyLink,
        RubyPut,
        Script,
        ScriptAdd,
        ScriptCode,
        ScriptCodeOriginal,
        ScriptCodeRed,
        ScriptDelete,
        ScriptEdit,
        ScriptError,
        ScriptGear,
        ScriptGo,
        ScriptKey,
        ScriptLightning,
        ScriptLink,
        ScriptPalette,
        ScriptSave,
        ScriptStart,
        ScriptStop,
        Seasons,
        SectionCollapsed,
        SectionExpanded,
        Server,
        ServerAdd,
        ServerChart,
        ServerCompressed,
        ServerConnect,
        ServerDatabase,
        ServerDelete,
        ServerEdit,
        ServerError,
        ServerGo,
        ServerKey,
        ServerLightning,
        ServerLink,
        ServerStart,
        ServerStop,
        ServerUncompressed,
        ServerWrench,
        Shading,
        ShapesMany,
        ShapesManySelect,
        Shape3d,
        ShapeAlignBottom,
        ShapeAlignCenter,
        ShapeAlignLeft,
        ShapeAlignMiddle,
        ShapeAlignRight,
        ShapeAlignTop,
        ShapeFlipHorizontal,
        ShapeFlipVertical,
        ShapeGroup,
        ShapeHandles,
        ShapeMoveBack,
        ShapeMoveBackwards,
        ShapeMoveForwards,
        ShapeMoveFront,
        ShapeRotateAnticlockwise,
        ShapeRotateClockwise,
        ShapeShadeA,
        ShapeShadeB,
        ShapeShadeC,
        ShapeShadow,
        ShapeShadowToggle,
        ShapeSquare,
        ShapeSquareAdd,
        ShapeSquareDelete,
        ShapeSquareEdit,
        ShapeSquareError,
        ShapeSquareGo,
        ShapeSquareKey,
        ShapeSquareLink,
        ShapeSquareSelect,
        ShapeUngroup,
        Share,
        Shield,
        ShieldAdd,
        ShieldDelete,
        ShieldError,
        ShieldGo,
        ShieldRainbow,
        ShieldSilver,
        ShieldStart,
        ShieldStop,
        Sitemap,
        SitemapColor,
        Smartphone,
        SmartphoneAdd,
        SmartphoneConnect,
        SmartphoneDelete,
        SmartphoneDisk,
        SmartphoneEdit,
        SmartphoneError,
        SmartphoneGo,
        SmartphoneKey,
        SmartphoneWrench,
        SortAscending,
        SortDescending,
        Sound,
        SoundAdd,
        SoundDelete,
        SoundHigh,
        SoundIn,
        SoundLow,
        SoundMute,
        SoundNone,
        SoundOut,
        Spellcheck,
        Sport8ball,
        SportBasketball,
        SportFootball,
        SportGolf,
        SportGolfPractice,
        SportRaquet,
        SportShuttlecock,
        SportSoccer,
        SportTennis,
        Star,
        StarBronze,
        StarBronzeHalfGrey,
        StarGold,
        StarGoldHalfGrey,
        StarGoldHalfSilver,
        StarGrey,
        StarHalfGrey,
        StarSilver,
        StatusAway,
        StatusBeRightBack,
        StatusBusy,
        StatusInvisible,
        StatusOffline,
        StatusOnline,
        Stop,
        StopBlue,
        StopGreen,
        StopRed,
        Style,
        StyleAdd,
        StyleDelete,
        StyleEdit,
        StyleGo,
        Sum,
        Tab,
        Table,
        TableAdd,
        TableCell,
        TableColumn,
        TableColumnAdd,
        TableColumnDelete,
        TableConnect,
        TableDelete,
        TableEdit,
        TableError,
        TableGear,
        TableGo,
        TableKey,
        TableLightning,
        TableLink,
        TableMultiple,
        TableRefresh,
        TableRelationship,
        TableRow,
        TableRowDelete,
        TableRowInsert,
        TableSave,
        TableSort,
        TabAdd,
        TabBlue,
        TabDelete,
        TabEdit,
        TabGo,
        TabGreen,
        TabRed,
        Tag,
        TagsGrey,
        TagsRed,
        TagBlue,
        TagBlueAdd,
        TagBlueDelete,
        TagBlueEdit,
        TagGreen,
        TagOrange,
        TagPink,
        TagPurple,
        TagRed,
        TagYellow,
        Telephone,
        TelephoneAdd,
        TelephoneDelete,
        TelephoneEdit,
        TelephoneError,
        TelephoneGo,
        TelephoneKey,
        TelephoneLink,
        TelephoneRed,
        Television,
        TelevisionAdd,
        TelevisionDelete,
        TelevisionIn,
        TelevisionOff,
        TelevisionOut,
        TelevisionStar,
        Textfield,
        TextfieldAdd,
        TextfieldDelete,
        TextfieldKey,
        TextfieldRename,
        TextAb,
        TextAlignCenter,
        TextAlignJustify,
        TextAlignLeft,
        TextAlignRight,
        TextAllcaps,
        TextBold,
        TextColumns,
        TextComplete,
        TextDirection,
        TextDoubleUnderline,
        TextDropcaps,
        TextFit,
        TextFlip,
        TextFontDefault,
        TextHeading1,
        TextHeading2,
        TextHeading3,
        TextHeading4,
        TextHeading5,
        TextHeading6,
        TextHorizontalrule,
        TextIndent,
        TextIndentRemove,
        TextInverse,
        TextItalic,
        TextKerning,
        TextLeftToRight,
        TextLetterspacing,
        TextLetterOmega,
        TextLinespacing,
        TextListBullets,
        TextListNumbers,
        TextLowercase,
        TextLowercaseA,
        TextMirror,
        TextPaddingBottom,
        TextPaddingLeft,
        TextPaddingRight,
        TextPaddingTop,
        TextReplace,
        TextRightToLeft,
        TextRotate0,
        TextRotate180,
        TextRotate270,
        TextRotate90,
        TextRuler,
        TextShading,
        TextSignature,
        TextSmallcaps,
        TextSpelling,
        TextStrikethrough,
        TextSubscript,
        TextSuperscript,
        TextTab,
        TextUnderline,
        TextUppercase,
        Theme,
        ThumbDown,
        ThumbUp,
        Tick,
        Time,
        TimelineMarker,
        TimeAdd,
        TimeDelete,
        TimeGo,
        TimeGreen,
        TimeRed,
        Transmit,
        TransmitAdd,
        TransmitBlue,
        TransmitDelete,
        TransmitEdit,
        TransmitError,
        TransmitGo,
        TransmitRed,
        Tux,
        User,
        UserAdd,
        UserAlert,
        UserB,
        UserBrown,
        UserComment,
        UserCross,
        UserDelete,
        UserEarth,
        UserEdit,
        UserFemale,
        UserGo,
        UserGray,
        UserGrayCool,
        UserGreen,
        UserHome,
        UserKey,
        UserMagnify,
        UserMature,
        UserOrange,
        UserRed,
        UserStar,
        UserSuit,
        UserSuitBlack,
        UserTick,
        Vcard,
        VcardAdd,
        VcardDelete,
        VcardEdit,
        VcardKey,
        Vector,
        VectorAdd,
        VectorDelete,
        VectorKey,
        Wand,
        WeatherCloud,
        WeatherClouds,
        WeatherCloudy,
        WeatherCloudyRain,
        WeatherLightning,
        WeatherRain,
        WeatherSnow,
        WeatherSun,
        Webcam,
        WebcamAdd,
        WebcamConnect,
        WebcamDelete,
        WebcamError,
        WebcamStart,
        WebcamStop,
        World,
        WorldAdd,
        WorldConnect,
        WorldDawn,
        WorldDelete,
        WorldEdit,
        WorldGo,
        WorldKey,
        WorldLink,
        WorldNight,
        WorldOrbit,
        Wrench,
        WrenchOrange,
        Xhtml,
        XhtmlAdd,
        XhtmlDelete,
        XhtmlError,
        XhtmlGo,
        XhtmlValid,
        Zoom,
        ZoomIn,
        ZoomOut,
        SystemClose,
        SystemNew,
        SystemSave,
        SystemSaveClose,
        SystemSaveNew,
        SystemSearch
    }

    /// <summary>
    /// 预定义图标名称
    /// </summary>
    public static partial class IconHelper
    {
        public static string GetName(Icon type)
        {
            string result = String.Empty;

            switch (type)
            {
                case Icon.None:
                    result = "";
                    break;
                case Icon.Accept:
                    result = "accept.png";
                    break;
                case Icon.Add:
                    result = "add.png";
                    break;
                case Icon.Anchor:
                    result = "anchor.png";
                    break;
                case Icon.Application:
                    result = "application.png";
                    break;
                case Icon.ApplicationAdd:
                    result = "application_add.png";
                    break;
                case Icon.ApplicationCascade:
                    result = "application_cascade.png";
                    break;
                case Icon.ApplicationDelete:
                    result = "application_delete.png";
                    break;
                case Icon.ApplicationDouble:
                    result = "application_double.png";
                    break;
                case Icon.ApplicationEdit:
                    result = "application_edit.png";
                    break;
                case Icon.ApplicationError:
                    result = "application_error.png";
                    break;
                case Icon.ApplicationForm:
                    result = "application_form.png";
                    break;
                case Icon.ApplicationFormAdd:
                    result = "application_form_add.png";
                    break;
                case Icon.ApplicationFormDelete:
                    result = "application_form_delete.png";
                    break;
                case Icon.ApplicationFormEdit:
                    result = "application_form_edit.png";
                    break;
                case Icon.ApplicationFormMagnify:
                    result = "application_form_magnify.png";
                    break;
                case Icon.ApplicationGet:
                    result = "application_get.png";
                    break;
                case Icon.ApplicationGo:
                    result = "application_go.png";
                    break;
                case Icon.ApplicationHome:
                    result = "application_home.png";
                    break;
                case Icon.ApplicationKey:
                    result = "application_key.png";
                    break;
                case Icon.ApplicationLightning:
                    result = "application_lightning.png";
                    break;
                case Icon.ApplicationLink:
                    result = "application_link.png";
                    break;
                case Icon.ApplicationOsx:
                    result = "application_osx.png";
                    break;
                case Icon.ApplicationOsxAdd:
                    result = "application_osx_add.png";
                    break;
                case Icon.ApplicationOsxCascade:
                    result = "application_osx_cascade.png";
                    break;
                case Icon.ApplicationOsxDelete:
                    result = "application_osx_delete.png";
                    break;
                case Icon.ApplicationOsxDouble:
                    result = "application_osx_double.png";
                    break;
                case Icon.ApplicationOsxError:
                    result = "application_osx_error.png";
                    break;
                case Icon.ApplicationOsxGet:
                    result = "application_osx_get.png";
                    break;
                case Icon.ApplicationOsxGo:
                    result = "application_osx_go.png";
                    break;
                case Icon.ApplicationOsxHome:
                    result = "application_osx_home.png";
                    break;
                case Icon.ApplicationOsxKey:
                    result = "application_osx_key.png";
                    break;
                case Icon.ApplicationOsxLightning:
                    result = "application_osx_lightning.png";
                    break;
                case Icon.ApplicationOsxLink:
                    result = "application_osx_link.png";
                    break;
                case Icon.ApplicationOsxSplit:
                    result = "application_osx_split.png";
                    break;
                case Icon.ApplicationOsxStart:
                    result = "application_osx_start.png";
                    break;
                case Icon.ApplicationOsxStop:
                    result = "application_osx_stop.png";
                    break;
                case Icon.ApplicationOsxTerminal:
                    result = "application_osx_terminal.png";
                    break;
                case Icon.ApplicationPut:
                    result = "application_put.png";
                    break;
                case Icon.ApplicationSideBoxes:
                    result = "application_side_boxes.png";
                    break;
                case Icon.ApplicationSideContract:
                    result = "application_side_contract.png";
                    break;
                case Icon.ApplicationSideExpand:
                    result = "application_side_expand.png";
                    break;
                case Icon.ApplicationSideList:
                    result = "application_side_list.png";
                    break;
                case Icon.ApplicationSideTree:
                    result = "application_side_tree.png";
                    break;
                case Icon.ApplicationSplit:
                    result = "application_split.png";
                    break;
                case Icon.ApplicationStart:
                    result = "application_start.png";
                    break;
                case Icon.ApplicationStop:
                    result = "application_stop.png";
                    break;
                case Icon.ApplicationTileHorizontal:
                    result = "application_tile_horizontal.png";
                    break;
                case Icon.ApplicationTileVertical:
                    result = "application_tile_vertical.png";
                    break;
                case Icon.ApplicationViewColumns:
                    result = "application_view_columns.png";
                    break;
                case Icon.ApplicationViewDetail:
                    result = "application_view_detail.png";
                    break;
                case Icon.ApplicationViewGallery:
                    result = "application_view_gallery.png";
                    break;
                case Icon.ApplicationViewIcons:
                    result = "application_view_icons.png";
                    break;
                case Icon.ApplicationViewList:
                    result = "application_view_list.png";
                    break;
                case Icon.ApplicationViewTile:
                    result = "application_view_tile.png";
                    break;
                case Icon.ApplicationXp:
                    result = "application_xp.png";
                    break;
                case Icon.ApplicationXpTerminal:
                    result = "application_xp_terminal.png";
                    break;
                case Icon.ArrowBranch:
                    result = "arrow_branch.png";
                    break;
                case Icon.ArrowDivide:
                    result = "arrow_divide.png";
                    break;
                case Icon.ArrowDown:
                    result = "arrow_down.png";
                    break;
                case Icon.ArrowEw:
                    result = "arrow_ew.png";
                    break;
                case Icon.ArrowIn:
                    result = "arrow_in.png";
                    break;
                case Icon.ArrowInout:
                    result = "arrow_inout.png";
                    break;
                case Icon.ArrowInLonger:
                    result = "arrow_in_longer.png";
                    break;
                case Icon.ArrowJoin:
                    result = "arrow_join.png";
                    break;
                case Icon.ArrowLeft:
                    result = "arrow_left.png";
                    break;
                case Icon.ArrowMerge:
                    result = "arrow_merge.png";
                    break;
                case Icon.ArrowNe:
                    result = "arrow_ne.png";
                    break;
                case Icon.ArrowNs:
                    result = "arrow_ns.png";
                    break;
                case Icon.ArrowNsew:
                    result = "arrow_nsew.png";
                    break;
                case Icon.ArrowNw:
                    result = "arrow_nw.png";
                    break;
                case Icon.ArrowNwNeSwSe:
                    result = "arrow_nw_ne_sw_se.png";
                    break;
                case Icon.ArrowNwSe:
                    result = "arrow_nw_se.png";
                    break;
                case Icon.ArrowOut:
                    result = "arrow_out.png";
                    break;
                case Icon.ArrowOutLonger:
                    result = "arrow_out_longer.png";
                    break;
                case Icon.ArrowRedo:
                    result = "arrow_redo.png";
                    break;
                case Icon.ArrowRefresh:
                    result = "arrow_refresh.png";
                    break;
                case Icon.ArrowRefreshSmall:
                    result = "arrow_refresh_small.png";
                    break;
                case Icon.ArrowRight:
                    result = "arrow_right.png";
                    break;
                case Icon.ArrowRotateAnticlockwise:
                    result = "arrow_rotate_anticlockwise.png";
                    break;
                case Icon.ArrowRotateClockwise:
                    result = "arrow_rotate_clockwise.png";
                    break;
                case Icon.ArrowSe:
                    result = "arrow_se.png";
                    break;
                case Icon.ArrowSw:
                    result = "arrow_sw.png";
                    break;
                case Icon.ArrowSwitch:
                    result = "arrow_switch.png";
                    break;
                case Icon.ArrowSwitchBluegreen:
                    result = "arrow_switch_bluegreen.png";
                    break;
                case Icon.ArrowSwNe:
                    result = "arrow_sw_ne.png";
                    break;
                case Icon.ArrowTurnLeft:
                    result = "arrow_turn_left.png";
                    break;
                case Icon.ArrowTurnRight:
                    result = "arrow_turn_right.png";
                    break;
                case Icon.ArrowUndo:
                    result = "arrow_undo.png";
                    break;
                case Icon.ArrowUp:
                    result = "arrow_up.png";
                    break;
                case Icon.AsteriskOrange:
                    result = "asterisk_orange.png";
                    break;
                case Icon.AsteriskRed:
                    result = "asterisk_red.png";
                    break;
                case Icon.AsteriskYellow:
                    result = "asterisk_yellow.png";
                    break;
                case Icon.Attach:
                    result = "attach.png";
                    break;
                case Icon.AwardStarAdd:
                    result = "award_star_add.png";
                    break;
                case Icon.AwardStarBronze1:
                    result = "award_star_bronze_1.png";
                    break;
                case Icon.AwardStarBronze2:
                    result = "award_star_bronze_2.png";
                    break;
                case Icon.AwardStarBronze3:
                    result = "award_star_bronze_3.png";
                    break;
                case Icon.AwardStarDelete:
                    result = "award_star_delete.png";
                    break;
                case Icon.AwardStarGold1:
                    result = "award_star_gold_1.png";
                    break;
                case Icon.AwardStarGold2:
                    result = "award_star_gold_2.png";
                    break;
                case Icon.AwardStarGold3:
                    result = "award_star_gold_3.png";
                    break;
                case Icon.AwardStarSilver1:
                    result = "award_star_silver_1.png";
                    break;
                case Icon.AwardStarSilver2:
                    result = "award_star_silver_2.png";
                    break;
                case Icon.AwardStarSilver3:
                    result = "award_star_silver_3.png";
                    break;
                case Icon.Basket:
                    result = "basket.png";
                    break;
                case Icon.BasketAdd:
                    result = "basket_add.png";
                    break;
                case Icon.BasketDelete:
                    result = "basket_delete.png";
                    break;
                case Icon.BasketEdit:
                    result = "basket_edit.png";
                    break;
                case Icon.BasketError:
                    result = "basket_error.png";
                    break;
                case Icon.BasketGo:
                    result = "basket_go.png";
                    break;
                case Icon.BasketPut:
                    result = "basket_put.png";
                    break;
                case Icon.BasketRemove:
                    result = "basket_remove.png";
                    break;
                case Icon.Bell:
                    result = "bell.png";
                    break;
                case Icon.BellAdd:
                    result = "bell_add.png";
                    break;
                case Icon.BellDelete:
                    result = "bell_delete.png";
                    break;
                case Icon.BellError:
                    result = "bell_error.png";
                    break;
                case Icon.BellGo:
                    result = "bell_go.png";
                    break;
                case Icon.BellLink:
                    result = "bell_link.png";
                    break;
                case Icon.BellSilver:
                    result = "bell_silver.png";
                    break;
                case Icon.BellSilverStart:
                    result = "bell_silver_start.png";
                    break;
                case Icon.BellSilverStop:
                    result = "bell_silver_stop.png";
                    break;
                case Icon.BellStart:
                    result = "bell_start.png";
                    break;
                case Icon.BellStop:
                    result = "bell_stop.png";
                    break;
                case Icon.Bin:
                    result = "bin.png";
                    break;
                case Icon.BinClosed:
                    result = "bin_closed.png";
                    break;
                case Icon.BinEmpty:
                    result = "bin_empty.png";
                    break;
                case Icon.Blank:
                    result = "blank.png";
                    break;
                case Icon.Bomb:
                    result = "bomb.png";
                    break;
                case Icon.Book:
                    result = "book.png";
                    break;
                case Icon.Bookmark:
                    result = "bookmark.png";
                    break;
                case Icon.BookmarkAdd:
                    result = "bookmark_add.png";
                    break;
                case Icon.BookmarkDelete:
                    result = "bookmark_delete.png";
                    break;
                case Icon.BookmarkEdit:
                    result = "bookmark_edit.png";
                    break;
                case Icon.BookmarkError:
                    result = "bookmark_error.png";
                    break;
                case Icon.BookmarkGo:
                    result = "bookmark_go.png";
                    break;
                case Icon.BookAdd:
                    result = "book_add.png";
                    break;
                case Icon.BookAddresses:
                    result = "book_addresses.png";
                    break;
                case Icon.BookAddressesAdd:
                    result = "book_addresses_add.png";
                    break;
                case Icon.BookAddressesDelete:
                    result = "book_addresses_delete.png";
                    break;
                case Icon.BookAddressesEdit:
                    result = "book_addresses_edit.png";
                    break;
                case Icon.BookAddressesError:
                    result = "book_addresses_error.png";
                    break;
                case Icon.BookAddressesKey:
                    result = "book_addresses_key.png";
                    break;
                case Icon.BookDelete:
                    result = "book_delete.png";
                    break;
                case Icon.BookEdit:
                    result = "book_edit.png";
                    break;
                case Icon.BookError:
                    result = "book_error.png";
                    break;
                case Icon.BookGo:
                    result = "book_go.png";
                    break;
                case Icon.BookKey:
                    result = "book_key.png";
                    break;
                case Icon.BookLink:
                    result = "book_link.png";
                    break;
                case Icon.BookMagnify:
                    result = "book_magnify.png";
                    break;
                case Icon.BookNext:
                    result = "book_next.png";
                    break;
                case Icon.BookOpen:
                    result = "book_open.png";
                    break;
                case Icon.BookOpenMark:
                    result = "book_open_mark.png";
                    break;
                case Icon.BookPrevious:
                    result = "book_previous.png";
                    break;
                case Icon.BookRed:
                    result = "book_red.png";
                    break;
                case Icon.BookTabs:
                    result = "book_tabs.png";
                    break;
                case Icon.BorderAll:
                    result = "border_all.png";
                    break;
                case Icon.BorderBottom:
                    result = "border_bottom.png";
                    break;
                case Icon.BorderDraw:
                    result = "border_draw.png";
                    break;
                case Icon.BorderInner:
                    result = "border_inner.png";
                    break;
                case Icon.BorderInnerHorizontal:
                    result = "border_inner_horizontal.png";
                    break;
                case Icon.BorderInnerVertical:
                    result = "border_inner_vertical.png";
                    break;
                case Icon.BorderLeft:
                    result = "border_left.png";
                    break;
                case Icon.BorderNone:
                    result = "border_none.png";
                    break;
                case Icon.BorderOuter:
                    result = "border_outer.png";
                    break;
                case Icon.BorderRight:
                    result = "border_right.png";
                    break;
                case Icon.BorderTop:
                    result = "border_top.png";
                    break;
                case Icon.Box:
                    result = "box.png";
                    break;
                case Icon.BoxError:
                    result = "box_error.png";
                    break;
                case Icon.BoxPicture:
                    result = "box_picture.png";
                    break;
                case Icon.BoxWorld:
                    result = "box_world.png";
                    break;
                case Icon.Brick:
                    result = "brick.png";
                    break;
                case Icon.Bricks:
                    result = "bricks.png";
                    break;
                case Icon.BrickAdd:
                    result = "brick_add.png";
                    break;
                case Icon.BrickDelete:
                    result = "brick_delete.png";
                    break;
                case Icon.BrickEdit:
                    result = "brick_edit.png";
                    break;
                case Icon.BrickError:
                    result = "brick_error.png";
                    break;
                case Icon.BrickGo:
                    result = "brick_go.png";
                    break;
                case Icon.BrickLink:
                    result = "brick_link.png";
                    break;
                case Icon.BrickMagnify:
                    result = "brick_magnify.png";
                    break;
                case Icon.Briefcase:
                    result = "briefcase.png";
                    break;
                case Icon.Bug:
                    result = "bug.png";
                    break;
                case Icon.BugAdd:
                    result = "bug_add.png";
                    break;
                case Icon.BugDelete:
                    result = "bug_delete.png";
                    break;
                case Icon.BugEdit:
                    result = "bug_edit.png";
                    break;
                case Icon.BugError:
                    result = "bug_error.png";
                    break;
                case Icon.BugFix:
                    result = "bug_fix.png";
                    break;
                case Icon.BugGo:
                    result = "bug_go.png";
                    break;
                case Icon.BugLink:
                    result = "bug_link.png";
                    break;
                case Icon.BugMagnify:
                    result = "bug_magnify.png";
                    break;
                case Icon.Build:
                    result = "build.png";
                    break;
                case Icon.Building:
                    result = "building.png";
                    break;
                case Icon.BuildingAdd:
                    result = "building_add.png";
                    break;
                case Icon.BuildingDelete:
                    result = "building_delete.png";
                    break;
                case Icon.BuildingEdit:
                    result = "building_edit.png";
                    break;
                case Icon.BuildingError:
                    result = "building_error.png";
                    break;
                case Icon.BuildingGo:
                    result = "building_go.png";
                    break;
                case Icon.BuildingKey:
                    result = "building_key.png";
                    break;
                case Icon.BuildingLink:
                    result = "building_link.png";
                    break;
                case Icon.BuildCancel:
                    result = "build_cancel.png";
                    break;
                case Icon.BulletAdd:
                    result = "bullet_add.png";
                    break;
                case Icon.BulletArrowBottom:
                    result = "bullet_arrow_bottom.png";
                    break;
                case Icon.BulletArrowDown:
                    result = "bullet_arrow_down.png";
                    break;
                case Icon.BulletArrowTop:
                    result = "bullet_arrow_top.png";
                    break;
                case Icon.BulletArrowUp:
                    result = "bullet_arrow_up.png";
                    break;
                case Icon.BulletBlack:
                    result = "bullet_black.png";
                    break;
                case Icon.BulletBlue:
                    result = "bullet_blue.png";
                    break;
                case Icon.BulletConnect:
                    result = "bullet_connect.png";
                    break;
                case Icon.BulletCross:
                    result = "bullet_cross.png";
                    break;
                case Icon.BulletDatabase:
                    result = "bullet_database.png";
                    break;
                case Icon.BulletDatabaseYellow:
                    result = "bullet_database_yellow.png";
                    break;
                case Icon.BulletDelete:
                    result = "bullet_delete.png";
                    break;
                case Icon.BulletDisk:
                    result = "bullet_disk.png";
                    break;
                case Icon.BulletEarth:
                    result = "bullet_earth.png";
                    break;
                case Icon.BulletEdit:
                    result = "bullet_edit.png";
                    break;
                case Icon.BulletEject:
                    result = "bullet_eject.png";
                    break;
                case Icon.BulletError:
                    result = "bullet_error.png";
                    break;
                case Icon.BulletFeed:
                    result = "bullet_feed.png";
                    break;
                case Icon.BulletGet:
                    result = "bullet_get.png";
                    break;
                case Icon.BulletGo:
                    result = "bullet_go.png";
                    break;
                case Icon.BulletGreen:
                    result = "bullet_green.png";
                    break;
                case Icon.BulletHome:
                    result = "bullet_home.png";
                    break;
                case Icon.BulletKey:
                    result = "bullet_key.png";
                    break;
                case Icon.BulletLeft:
                    result = "bullet_left.png";
                    break;
                case Icon.BulletLightning:
                    result = "bullet_lightning.png";
                    break;
                case Icon.BulletMagnify:
                    result = "bullet_magnify.png";
                    break;
                case Icon.BulletMinus:
                    result = "bullet_minus.png";
                    break;
                case Icon.BulletOrange:
                    result = "bullet_orange.png";
                    break;
                case Icon.BulletPageWhite:
                    result = "bullet_page_white.png";
                    break;
                case Icon.BulletPicture:
                    result = "bullet_picture.png";
                    break;
                case Icon.BulletPink:
                    result = "bullet_pink.png";
                    break;
                case Icon.BulletPlus:
                    result = "bullet_plus.png";
                    break;
                case Icon.BulletPurple:
                    result = "bullet_purple.png";
                    break;
                case Icon.BulletRed:
                    result = "bullet_red.png";
                    break;
                case Icon.BulletRight:
                    result = "bullet_right.png";
                    break;
                case Icon.BulletShape:
                    result = "bullet_shape.png";
                    break;
                case Icon.BulletSparkle:
                    result = "bullet_sparkle.png";
                    break;
                case Icon.BulletStar:
                    result = "bullet_star.png";
                    break;
                case Icon.BulletStart:
                    result = "bullet_start.png";
                    break;
                case Icon.BulletStop:
                    result = "bullet_stop.png";
                    break;
                case Icon.BulletStopAlt:
                    result = "bullet_stop_alt.png";
                    break;
                case Icon.BulletTick:
                    result = "bullet_tick.png";
                    break;
                case Icon.BulletToggleMinus:
                    result = "bullet_toggle_minus.png";
                    break;
                case Icon.BulletTogglePlus:
                    result = "bullet_toggle_plus.png";
                    break;
                case Icon.BulletWhite:
                    result = "bullet_white.png";
                    break;
                case Icon.BulletWrench:
                    result = "bullet_wrench.png";
                    break;
                case Icon.BulletWrenchRed:
                    result = "bullet_wrench_red.png";
                    break;
                case Icon.BulletYellow:
                    result = "bullet_yellow.png";
                    break;
                case Icon.Button:
                    result = "button.png";
                    break;
                case Icon.Cake:
                    result = "cake.png";
                    break;
                case Icon.CakeOut:
                    result = "cake_out.png";
                    break;
                case Icon.CakeSliced:
                    result = "cake_sliced.png";
                    break;
                case Icon.Calculator:
                    result = "calculator.png";
                    break;
                case Icon.CalculatorAdd:
                    result = "calculator_add.png";
                    break;
                case Icon.CalculatorDelete:
                    result = "calculator_delete.png";
                    break;
                case Icon.CalculatorEdit:
                    result = "calculator_edit.png";
                    break;
                case Icon.CalculatorError:
                    result = "calculator_error.png";
                    break;
                case Icon.CalculatorLink:
                    result = "calculator_link.png";
                    break;
                case Icon.Calendar:
                    result = "calendar.png";
                    break;
                case Icon.CalendarAdd:
                    result = "calendar_add.png";
                    break;
                case Icon.CalendarDelete:
                    result = "calendar_delete.png";
                    break;
                case Icon.CalendarEdit:
                    result = "calendar_edit.png";
                    break;
                case Icon.CalendarLink:
                    result = "calendar_link.png";
                    break;
                case Icon.CalendarSelectDay:
                    result = "calendar_select_day.png";
                    break;
                case Icon.CalendarSelectNone:
                    result = "calendar_select_none.png";
                    break;
                case Icon.CalendarSelectWeek:
                    result = "calendar_select_week.png";
                    break;
                case Icon.CalendarStar:
                    result = "calendar_star.png";
                    break;
                case Icon.CalendarViewDay:
                    result = "calendar_view_day.png";
                    break;
                case Icon.CalendarViewMonth:
                    result = "calendar_view_month.png";
                    break;
                case Icon.CalendarViewWeek:
                    result = "calendar_view_week.png";
                    break;
                case Icon.Camera:
                    result = "camera.png";
                    break;
                case Icon.CameraAdd:
                    result = "camera_add.png";
                    break;
                case Icon.CameraConnect:
                    result = "camera_connect.png";
                    break;
                case Icon.CameraDelete:
                    result = "camera_delete.png";
                    break;
                case Icon.CameraEdit:
                    result = "camera_edit.png";
                    break;
                case Icon.CameraError:
                    result = "camera_error.png";
                    break;
                case Icon.CameraGo:
                    result = "camera_go.png";
                    break;
                case Icon.CameraLink:
                    result = "camera_link.png";
                    break;
                case Icon.CameraMagnify:
                    result = "camera_magnify.png";
                    break;
                case Icon.CameraPicture:
                    result = "camera_picture.png";
                    break;
                case Icon.CameraSmall:
                    result = "camera_small.png";
                    break;
                case Icon.CameraStart:
                    result = "camera_start.png";
                    break;
                case Icon.CameraStop:
                    result = "camera_stop.png";
                    break;
                case Icon.Cancel:
                    result = "cancel.png";
                    break;
                case Icon.Car:
                    result = "car.png";
                    break;
                case Icon.Cart:
                    result = "cart.png";
                    break;
                case Icon.CartAdd:
                    result = "cart_add.png";
                    break;
                case Icon.CartDelete:
                    result = "cart_delete.png";
                    break;
                case Icon.CartEdit:
                    result = "cart_edit.png";
                    break;
                case Icon.CartError:
                    result = "cart_error.png";
                    break;
                case Icon.CartFull:
                    result = "cart_full.png";
                    break;
                case Icon.CartGo:
                    result = "cart_go.png";
                    break;
                case Icon.CartMagnify:
                    result = "cart_magnify.png";
                    break;
                case Icon.CartPut:
                    result = "cart_put.png";
                    break;
                case Icon.CartRemove:
                    result = "cart_remove.png";
                    break;
                case Icon.CarAdd:
                    result = "car_add.png";
                    break;
                case Icon.CarDelete:
                    result = "car_delete.png";
                    break;
                case Icon.CarError:
                    result = "car_error.png";
                    break;
                case Icon.CarRed:
                    result = "car_red.png";
                    break;
                case Icon.CarStart:
                    result = "car_start.png";
                    break;
                case Icon.CarStop:
                    result = "car_stop.png";
                    break;
                case Icon.Cd:
                    result = "cd.png";
                    break;
                case Icon.Cdr:
                    result = "cdr.png";
                    break;
                case Icon.CdrAdd:
                    result = "cdr_add.png";
                    break;
                case Icon.CdrBurn:
                    result = "cdr_burn.png";
                    break;
                case Icon.CdrCross:
                    result = "cdr_cross.png";
                    break;
                case Icon.CdrDelete:
                    result = "cdr_delete.png";
                    break;
                case Icon.CdrEdit:
                    result = "cdr_edit.png";
                    break;
                case Icon.CdrEject:
                    result = "cdr_eject.png";
                    break;
                case Icon.CdrError:
                    result = "cdr_error.png";
                    break;
                case Icon.CdrGo:
                    result = "cdr_go.png";
                    break;
                case Icon.CdrMagnify:
                    result = "cdr_magnify.png";
                    break;
                case Icon.CdrPlay:
                    result = "cdr_play.png";
                    break;
                case Icon.CdrStart:
                    result = "cdr_start.png";
                    break;
                case Icon.CdrStop:
                    result = "cdr_stop.png";
                    break;
                case Icon.CdrStopAlt:
                    result = "cdr_stop_alt.png";
                    break;
                case Icon.CdrTick:
                    result = "cdr_tick.png";
                    break;
                case Icon.CdAdd:
                    result = "cd_add.png";
                    break;
                case Icon.CdBurn:
                    result = "cd_burn.png";
                    break;
                case Icon.CdDelete:
                    result = "cd_delete.png";
                    break;
                case Icon.CdEdit:
                    result = "cd_edit.png";
                    break;
                case Icon.CdEject:
                    result = "cd_eject.png";
                    break;
                case Icon.CdGo:
                    result = "cd_go.png";
                    break;
                case Icon.CdMagnify:
                    result = "cd_magnify.png";
                    break;
                case Icon.CdPlay:
                    result = "cd_play.png";
                    break;
                case Icon.CdStop:
                    result = "cd_stop.png";
                    break;
                case Icon.CdStopAlt:
                    result = "cd_stop_alt.png";
                    break;
                case Icon.CdTick:
                    result = "cd_tick.png";
                    break;
                case Icon.ChartBar:
                    result = "chart_bar.png";
                    break;
                case Icon.ChartBarAdd:
                    result = "chart_bar_add.png";
                    break;
                case Icon.ChartBarDelete:
                    result = "chart_bar_delete.png";
                    break;
                case Icon.ChartBarEdit:
                    result = "chart_bar_edit.png";
                    break;
                case Icon.ChartBarError:
                    result = "chart_bar_error.png";
                    break;
                case Icon.ChartBarLink:
                    result = "chart_bar_link.png";
                    break;
                case Icon.ChartCurve:
                    result = "chart_curve.png";
                    break;
                case Icon.ChartCurveAdd:
                    result = "chart_curve_add.png";
                    break;
                case Icon.ChartCurveDelete:
                    result = "chart_curve_delete.png";
                    break;
                case Icon.ChartCurveEdit:
                    result = "chart_curve_edit.png";
                    break;
                case Icon.ChartCurveError:
                    result = "chart_curve_error.png";
                    break;
                case Icon.ChartCurveGo:
                    result = "chart_curve_go.png";
                    break;
                case Icon.ChartCurveLink:
                    result = "chart_curve_link.png";
                    break;
                case Icon.ChartLine:
                    result = "chart_line.png";
                    break;
                case Icon.ChartLineAdd:
                    result = "chart_line_add.png";
                    break;
                case Icon.ChartLineDelete:
                    result = "chart_line_delete.png";
                    break;
                case Icon.ChartLineEdit:
                    result = "chart_line_edit.png";
                    break;
                case Icon.ChartLineError:
                    result = "chart_line_error.png";
                    break;
                case Icon.ChartLineLink:
                    result = "chart_line_link.png";
                    break;
                case Icon.ChartOrganisation:
                    result = "chart_organisation.png";
                    break;
                case Icon.ChartOrganisationAdd:
                    result = "chart_organisation_add.png";
                    break;
                case Icon.ChartOrganisationDelete:
                    result = "chart_organisation_delete.png";
                    break;
                case Icon.ChartOrgInverted:
                    result = "chart_org_inverted.png";
                    break;
                case Icon.ChartPie:
                    result = "chart_pie.png";
                    break;
                case Icon.ChartPieAdd:
                    result = "chart_pie_add.png";
                    break;
                case Icon.ChartPieDelete:
                    result = "chart_pie_delete.png";
                    break;
                case Icon.ChartPieEdit:
                    result = "chart_pie_edit.png";
                    break;
                case Icon.ChartPieError:
                    result = "chart_pie_error.png";
                    break;
                case Icon.ChartPieLightning:
                    result = "chart_pie_lightning.png";
                    break;
                case Icon.ChartPieLink:
                    result = "chart_pie_link.png";
                    break;
                case Icon.CheckError:
                    result = "check_error.png";
                    break;
                case Icon.Clipboard:
                    result = "clipboard.png";
                    break;
                case Icon.Clock:
                    result = "clock.png";
                    break;
                case Icon.ClockAdd:
                    result = "clock_add.png";
                    break;
                case Icon.ClockDelete:
                    result = "clock_delete.png";
                    break;
                case Icon.ClockEdit:
                    result = "clock_edit.png";
                    break;
                case Icon.ClockError:
                    result = "clock_error.png";
                    break;
                case Icon.ClockGo:
                    result = "clock_go.png";
                    break;
                case Icon.ClockLink:
                    result = "clock_link.png";
                    break;
                case Icon.ClockPause:
                    result = "clock_pause.png";
                    break;
                case Icon.ClockPlay:
                    result = "clock_play.png";
                    break;
                case Icon.ClockRed:
                    result = "clock_red.png";
                    break;
                case Icon.ClockStart:
                    result = "clock_start.png";
                    break;
                case Icon.ClockStop:
                    result = "clock_stop.png";
                    break;
                case Icon.ClockStop2:
                    result = "clock_stop_2.png";
                    break;
                case Icon.Cmy:
                    result = "cmy.png";
                    break;
                case Icon.Cog:
                    result = "cog.png";
                    break;
                case Icon.CogAdd:
                    result = "cog_add.png";
                    break;
                case Icon.CogDelete:
                    result = "cog_delete.png";
                    break;
                case Icon.CogEdit:
                    result = "cog_edit.png";
                    break;
                case Icon.CogError:
                    result = "cog_error.png";
                    break;
                case Icon.CogGo:
                    result = "cog_go.png";
                    break;
                case Icon.CogStart:
                    result = "cog_start.png";
                    break;
                case Icon.CogStop:
                    result = "cog_stop.png";
                    break;
                case Icon.Coins:
                    result = "coins.png";
                    break;
                case Icon.CoinsAdd:
                    result = "coins_add.png";
                    break;
                case Icon.CoinsDelete:
                    result = "coins_delete.png";
                    break;
                case Icon.Color:
                    result = "color.png";
                    break;
                case Icon.ColorSwatch:
                    result = "color_swatch.png";
                    break;
                case Icon.ColorWheel:
                    result = "color_wheel.png";
                    break;
                case Icon.Comment:
                    result = "comment.png";
                    break;
                case Icon.Comments:
                    result = "comments.png";
                    break;
                case Icon.CommentsAdd:
                    result = "comments_add.png";
                    break;
                case Icon.CommentsDelete:
                    result = "comments_delete.png";
                    break;
                case Icon.CommentAdd:
                    result = "comment_add.png";
                    break;
                case Icon.CommentDelete:
                    result = "comment_delete.png";
                    break;
                case Icon.CommentDull:
                    result = "comment_dull.png";
                    break;
                case Icon.CommentEdit:
                    result = "comment_edit.png";
                    break;
                case Icon.CommentPlay:
                    result = "comment_play.png";
                    break;
                case Icon.CommentRecord:
                    result = "comment_record.png";
                    break;
                case Icon.Compass:
                    result = "compass.png";
                    break;
                case Icon.Compress:
                    result = "compress.png";
                    break;
                case Icon.Computer:
                    result = "computer.png";
                    break;
                case Icon.ComputerAdd:
                    result = "computer_add.png";
                    break;
                case Icon.ComputerConnect:
                    result = "computer_connect.png";
                    break;
                case Icon.ComputerDelete:
                    result = "computer_delete.png";
                    break;
                case Icon.ComputerEdit:
                    result = "computer_edit.png";
                    break;
                case Icon.ComputerError:
                    result = "computer_error.png";
                    break;
                case Icon.ComputerGo:
                    result = "computer_go.png";
                    break;
                case Icon.ComputerKey:
                    result = "computer_key.png";
                    break;
                case Icon.ComputerLink:
                    result = "computer_link.png";
                    break;
                case Icon.ComputerMagnify:
                    result = "computer_magnify.png";
                    break;
                case Icon.ComputerOff:
                    result = "computer_off.png";
                    break;
                case Icon.ComputerStart:
                    result = "computer_start.png";
                    break;
                case Icon.ComputerStop:
                    result = "computer_stop.png";
                    break;
                case Icon.ComputerWrench:
                    result = "computer_wrench.png";
                    break;
                case Icon.Connect:
                    result = "connect.png";
                    break;
                case Icon.Contrast:
                    result = "contrast.png";
                    break;
                case Icon.ContrastDecrease:
                    result = "contrast_decrease.png";
                    break;
                case Icon.ContrastHigh:
                    result = "contrast_high.png";
                    break;
                case Icon.ContrastIncrease:
                    result = "contrast_increase.png";
                    break;
                case Icon.ContrastLow:
                    result = "contrast_low.png";
                    break;
                case Icon.Controller:
                    result = "controller.png";
                    break;
                case Icon.ControllerAdd:
                    result = "controller_add.png";
                    break;
                case Icon.ControllerDelete:
                    result = "controller_delete.png";
                    break;
                case Icon.ControllerError:
                    result = "controller_error.png";
                    break;
                case Icon.ControlAdd:
                    result = "control_add.png";
                    break;
                case Icon.ControlAddBlue:
                    result = "control_add_blue.png";
                    break;
                case Icon.ControlBlank:
                    result = "control_blank.png";
                    break;
                case Icon.ControlBlankBlue:
                    result = "control_blank_blue.png";
                    break;
                case Icon.ControlEject:
                    result = "control_eject.png";
                    break;
                case Icon.ControlEjectBlue:
                    result = "control_eject_blue.png";
                    break;
                case Icon.ControlEnd:
                    result = "control_end.png";
                    break;
                case Icon.ControlEndBlue:
                    result = "control_end_blue.png";
                    break;
                case Icon.ControlEqualizer:
                    result = "control_equalizer.png";
                    break;
                case Icon.ControlEqualizerBlue:
                    result = "control_equalizer_blue.png";
                    break;
                case Icon.ControlFastforward:
                    result = "control_fastforward.png";
                    break;
                case Icon.ControlFastforwardBlue:
                    result = "control_fastforward_blue.png";
                    break;
                case Icon.ControlPause:
                    result = "control_pause.png";
                    break;
                case Icon.ControlPauseBlue:
                    result = "control_pause_blue.png";
                    break;
                case Icon.ControlPlay:
                    result = "control_play.png";
                    break;
                case Icon.ControlPlayBlue:
                    result = "control_play_blue.png";
                    break;
                case Icon.ControlPower:
                    result = "control_power.png";
                    break;
                case Icon.ControlPowerBlue:
                    result = "control_power_blue.png";
                    break;
                case Icon.ControlRecord:
                    result = "control_record.png";
                    break;
                case Icon.ControlRecordBlue:
                    result = "control_record_blue.png";
                    break;
                case Icon.ControlRemove:
                    result = "control_remove.png";
                    break;
                case Icon.ControlRemoveBlue:
                    result = "control_remove_blue.png";
                    break;
                case Icon.ControlRepeat:
                    result = "control_repeat.png";
                    break;
                case Icon.ControlRepeatBlue:
                    result = "control_repeat_blue.png";
                    break;
                case Icon.ControlRewind:
                    result = "control_rewind.png";
                    break;
                case Icon.ControlRewindBlue:
                    result = "control_rewind_blue.png";
                    break;
                case Icon.ControlStart:
                    result = "control_start.png";
                    break;
                case Icon.ControlStartBlue:
                    result = "control_start_blue.png";
                    break;
                case Icon.ControlStop:
                    result = "control_stop.png";
                    break;
                case Icon.ControlStopBlue:
                    result = "control_stop_blue.png";
                    break;
                case Icon.Creditcards:
                    result = "creditcards.png";
                    break;
                case Icon.Cross:
                    result = "cross.png";
                    break;
                case Icon.Css:
                    result = "css.png";
                    break;
                case Icon.CssAdd:
                    result = "css_add.png";
                    break;
                case Icon.CssDelete:
                    result = "css_delete.png";
                    break;
                case Icon.CssError:
                    result = "css_error.png";
                    break;
                case Icon.CssGo:
                    result = "css_go.png";
                    break;
                case Icon.CssValid:
                    result = "css_valid.png";
                    break;
                case Icon.Cup:
                    result = "cup.png";
                    break;
                case Icon.CupAdd:
                    result = "cup_add.png";
                    break;
                case Icon.CupBlack:
                    result = "cup_black.png";
                    break;
                case Icon.CupDelete:
                    result = "cup_delete.png";
                    break;
                case Icon.CupEdit:
                    result = "cup_edit.png";
                    break;
                case Icon.CupError:
                    result = "cup_error.png";
                    break;
                case Icon.CupGo:
                    result = "cup_go.png";
                    break;
                case Icon.CupGreen:
                    result = "cup_green.png";
                    break;
                case Icon.CupKey:
                    result = "cup_key.png";
                    break;
                case Icon.CupLink:
                    result = "cup_link.png";
                    break;
                case Icon.CupTea:
                    result = "cup_tea.png";
                    break;
                case Icon.Cursor:
                    result = "cursor.png";
                    break;
                case Icon.CursorSmall:
                    result = "cursor_small.png";
                    break;
                case Icon.Cut:
                    result = "cut.png";
                    break;
                case Icon.CutRed:
                    result = "cut_red.png";
                    break;
                case Icon.Database:
                    result = "database.png";
                    break;
                case Icon.DatabaseAdd:
                    result = "database_add.png";
                    break;
                case Icon.DatabaseConnect:
                    result = "database_connect.png";
                    break;
                case Icon.DatabaseCopy:
                    result = "database_copy.png";
                    break;
                case Icon.DatabaseDelete:
                    result = "database_delete.png";
                    break;
                case Icon.DatabaseEdit:
                    result = "database_edit.png";
                    break;
                case Icon.DatabaseError:
                    result = "database_error.png";
                    break;
                case Icon.DatabaseGear:
                    result = "database_gear.png";
                    break;
                case Icon.DatabaseGo:
                    result = "database_go.png";
                    break;
                case Icon.DatabaseKey:
                    result = "database_key.png";
                    break;
                case Icon.DatabaseLightning:
                    result = "database_lightning.png";
                    break;
                case Icon.DatabaseLink:
                    result = "database_link.png";
                    break;
                case Icon.DatabaseRefresh:
                    result = "database_refresh.png";
                    break;
                case Icon.DatabaseSave:
                    result = "database_save.png";
                    break;
                case Icon.DatabaseStart:
                    result = "database_start.png";
                    break;
                case Icon.DatabaseStop:
                    result = "database_stop.png";
                    break;
                case Icon.DatabaseTable:
                    result = "database_table.png";
                    break;
                case Icon.DatabaseWrench:
                    result = "database_wrench.png";
                    break;
                case Icon.DatabaseYellow:
                    result = "database_yellow.png";
                    break;
                case Icon.DatabaseYellowStart:
                    result = "database_yellow_start.png";
                    break;
                case Icon.DatabaseYellowStop:
                    result = "database_yellow_stop.png";
                    break;
                case Icon.Date:
                    result = "date.png";
                    break;
                case Icon.DateAdd:
                    result = "date_add.png";
                    break;
                case Icon.DateDelete:
                    result = "date_delete.png";
                    break;
                case Icon.DateEdit:
                    result = "date_edit.png";
                    break;
                case Icon.DateError:
                    result = "date_error.png";
                    break;
                case Icon.DateGo:
                    result = "date_go.png";
                    break;
                case Icon.DateLink:
                    result = "date_link.png";
                    break;
                case Icon.DateMagnify:
                    result = "date_magnify.png";
                    break;
                case Icon.DateNext:
                    result = "date_next.png";
                    break;
                case Icon.DatePrevious:
                    result = "date_previous.png";
                    break;
                case Icon.Decline:
                    result = "decline.png";
                    break;
                case Icon.Delete:
                    result = "delete.png";
                    break;
                case Icon.DeviceStylus:
                    result = "device_stylus.png";
                    break;
                case Icon.Disconnect:
                    result = "disconnect.png";
                    break;
                case Icon.Disk:
                    result = "disk.png";
                    break;
                case Icon.DiskBlack:
                    result = "disk_black.png";
                    break;
                case Icon.DiskBlackError:
                    result = "disk_black_error.png";
                    break;
                case Icon.DiskBlackMagnify:
                    result = "disk_black_magnify.png";
                    break;
                case Icon.DiskDownload:
                    result = "disk_download.png";
                    break;
                case Icon.DiskEdit:
                    result = "disk_edit.png";
                    break;
                case Icon.DiskError:
                    result = "disk_error.png";
                    break;
                case Icon.DiskMagnify:
                    result = "disk_magnify.png";
                    break;
                case Icon.DiskMultiple:
                    result = "disk_multiple.png";
                    break;
                case Icon.DiskUpload:
                    result = "disk_upload.png";
                    break;
                case Icon.Door:
                    result = "door.png";
                    break;
                case Icon.DoorError:
                    result = "door_error.png";
                    break;
                case Icon.DoorIn:
                    result = "door_in.png";
                    break;
                case Icon.DoorOpen:
                    result = "door_open.png";
                    break;
                case Icon.DoorOut:
                    result = "door_out.png";
                    break;
                case Icon.Drink:
                    result = "drink.png";
                    break;
                case Icon.DrinkEmpty:
                    result = "drink_empty.png";
                    break;
                case Icon.DrinkRed:
                    result = "drink_red.png";
                    break;
                case Icon.Drive:
                    result = "drive.png";
                    break;
                case Icon.DriveAdd:
                    result = "drive_add.png";
                    break;
                case Icon.DriveBurn:
                    result = "drive_burn.png";
                    break;
                case Icon.DriveCd:
                    result = "drive_cd.png";
                    break;
                case Icon.DriveCdr:
                    result = "drive_cdr.png";
                    break;
                case Icon.DriveCdEmpty:
                    result = "drive_cd_empty.png";
                    break;
                case Icon.DriveDelete:
                    result = "drive_delete.png";
                    break;
                case Icon.DriveDisk:
                    result = "drive_disk.png";
                    break;
                case Icon.DriveEdit:
                    result = "drive_edit.png";
                    break;
                case Icon.DriveError:
                    result = "drive_error.png";
                    break;
                case Icon.DriveGo:
                    result = "drive_go.png";
                    break;
                case Icon.DriveKey:
                    result = "drive_key.png";
                    break;
                case Icon.DriveLink:
                    result = "drive_link.png";
                    break;
                case Icon.DriveMagnify:
                    result = "drive_magnify.png";
                    break;
                case Icon.DriveNetwork:
                    result = "drive_network.png";
                    break;
                case Icon.DriveNetworkError:
                    result = "drive_network_error.png";
                    break;
                case Icon.DriveNetworkStop:
                    result = "drive_network_stop.png";
                    break;
                case Icon.DriveRename:
                    result = "drive_rename.png";
                    break;
                case Icon.DriveUser:
                    result = "drive_user.png";
                    break;
                case Icon.DriveWeb:
                    result = "drive_web.png";
                    break;
                case Icon.Dvd:
                    result = "dvd.png";
                    break;
                case Icon.DvdAdd:
                    result = "dvd_add.png";
                    break;
                case Icon.DvdDelete:
                    result = "dvd_delete.png";
                    break;
                case Icon.DvdEdit:
                    result = "dvd_edit.png";
                    break;
                case Icon.DvdError:
                    result = "dvd_error.png";
                    break;
                case Icon.DvdGo:
                    result = "dvd_go.png";
                    break;
                case Icon.DvdKey:
                    result = "dvd_key.png";
                    break;
                case Icon.DvdLink:
                    result = "dvd_link.png";
                    break;
                case Icon.DvdStart:
                    result = "dvd_start.png";
                    break;
                case Icon.DvdStop:
                    result = "dvd_stop.png";
                    break;
                case Icon.EjectBlue:
                    result = "eject_blue.png";
                    break;
                case Icon.EjectGreen:
                    result = "eject_green.png";
                    break;
                case Icon.Email:
                    result = "email.png";
                    break;
                case Icon.EmailAdd:
                    result = "email_add.png";
                    break;
                case Icon.EmailAttach:
                    result = "email_attach.png";
                    break;
                case Icon.EmailDelete:
                    result = "email_delete.png";
                    break;
                case Icon.EmailEdit:
                    result = "email_edit.png";
                    break;
                case Icon.EmailError:
                    result = "email_error.png";
                    break;
                case Icon.EmailGo:
                    result = "email_go.png";
                    break;
                case Icon.EmailLink:
                    result = "email_link.png";
                    break;
                case Icon.EmailMagnify:
                    result = "email_magnify.png";
                    break;
                case Icon.EmailOpen:
                    result = "email_open.png";
                    break;
                case Icon.EmailOpenImage:
                    result = "email_open_image.png";
                    break;
                case Icon.EmailStar:
                    result = "email_star.png";
                    break;
                case Icon.EmailStart:
                    result = "email_start.png";
                    break;
                case Icon.EmailStop:
                    result = "email_stop.png";
                    break;
                case Icon.EmailTransfer:
                    result = "email_transfer.png";
                    break;
                case Icon.EmoticonEvilgrin:
                    result = "emoticon_evilgrin.png";
                    break;
                case Icon.EmoticonGrin:
                    result = "emoticon_grin.png";
                    break;
                case Icon.EmoticonHappy:
                    result = "emoticon_happy.png";
                    break;
                case Icon.EmoticonSmile:
                    result = "emoticon_smile.png";
                    break;
                case Icon.EmoticonSurprised:
                    result = "emoticon_surprised.png";
                    break;
                case Icon.EmoticonTongue:
                    result = "emoticon_tongue.png";
                    break;
                case Icon.EmoticonUnhappy:
                    result = "emoticon_unhappy.png";
                    break;
                case Icon.EmoticonWaii:
                    result = "emoticon_waii.png";
                    break;
                case Icon.EmoticonWink:
                    result = "emoticon_wink.png";
                    break;
                case Icon.Erase:
                    result = "erase.png";
                    break;
                case Icon.Error:
                    result = "error.png";
                    break;
                case Icon.ErrorAdd:
                    result = "error_add.png";
                    break;
                case Icon.ErrorDelete:
                    result = "error_delete.png";
                    break;
                case Icon.ErrorGo:
                    result = "error_go.png";
                    break;
                case Icon.Exclamation:
                    result = "exclamation.png";
                    break;
                case Icon.Eye:
                    result = "eye.png";
                    break;
                case Icon.Eyes:
                    result = "eyes.png";
                    break;
                case Icon.Feed:
                    result = "feed.png";
                    break;
                case Icon.FeedAdd:
                    result = "feed_add.png";
                    break;
                case Icon.FeedDelete:
                    result = "feed_delete.png";
                    break;
                case Icon.FeedDisk:
                    result = "feed_disk.png";
                    break;
                case Icon.FeedEdit:
                    result = "feed_edit.png";
                    break;
                case Icon.FeedError:
                    result = "feed_error.png";
                    break;
                case Icon.FeedGo:
                    result = "feed_go.png";
                    break;
                case Icon.FeedKey:
                    result = "feed_key.png";
                    break;
                case Icon.FeedLink:
                    result = "feed_link.png";
                    break;
                case Icon.FeedMagnify:
                    result = "feed_magnify.png";
                    break;
                case Icon.FeedStar:
                    result = "feed_star.png";
                    break;
                case Icon.Female:
                    result = "female.png";
                    break;
                case Icon.Film:
                    result = "film.png";
                    break;
                case Icon.FilmAdd:
                    result = "film_add.png";
                    break;
                case Icon.FilmDelete:
                    result = "film_delete.png";
                    break;
                case Icon.FilmEdit:
                    result = "film_edit.png";
                    break;
                case Icon.FilmEject:
                    result = "film_eject.png";
                    break;
                case Icon.FilmError:
                    result = "film_error.png";
                    break;
                case Icon.FilmGo:
                    result = "film_go.png";
                    break;
                case Icon.FilmKey:
                    result = "film_key.png";
                    break;
                case Icon.FilmLink:
                    result = "film_link.png";
                    break;
                case Icon.FilmMagnify:
                    result = "film_magnify.png";
                    break;
                case Icon.FilmSave:
                    result = "film_save.png";
                    break;
                case Icon.FilmStar:
                    result = "film_star.png";
                    break;
                case Icon.FilmStart:
                    result = "film_start.png";
                    break;
                case Icon.FilmStop:
                    result = "film_stop.png";
                    break;
                case Icon.Find:
                    result = "find.png";
                    break;
                case Icon.FingerPoint:
                    result = "finger_point.png";
                    break;
                case Icon.FlagAd:
                    result = "flag_ad.png";
                    break;
                case Icon.FlagAe:
                    result = "flag_ae.png";
                    break;
                case Icon.FlagAf:
                    result = "flag_af.png";
                    break;
                case Icon.FlagAg:
                    result = "flag_ag.png";
                    break;
                case Icon.FlagAi:
                    result = "flag_ai.png";
                    break;
                case Icon.FlagAl:
                    result = "flag_al.png";
                    break;
                case Icon.FlagAm:
                    result = "flag_am.png";
                    break;
                case Icon.FlagAn:
                    result = "flag_an.png";
                    break;
                case Icon.FlagAo:
                    result = "flag_ao.png";
                    break;
                case Icon.FlagAr:
                    result = "flag_ar.png";
                    break;
                case Icon.FlagAs:
                    result = "flag_as.png";
                    break;
                case Icon.FlagAt:
                    result = "flag_at.png";
                    break;
                case Icon.FlagAu:
                    result = "flag_au.png";
                    break;
                case Icon.FlagAw:
                    result = "flag_aw.png";
                    break;
                case Icon.FlagAx:
                    result = "flag_ax.png";
                    break;
                case Icon.FlagAz:
                    result = "flag_az.png";
                    break;
                case Icon.FlagBa:
                    result = "flag_ba.png";
                    break;
                case Icon.FlagBb:
                    result = "flag_bb.png";
                    break;
                case Icon.FlagBd:
                    result = "flag_bd.png";
                    break;
                case Icon.FlagBe:
                    result = "flag_be.png";
                    break;
                case Icon.FlagBf:
                    result = "flag_bf.png";
                    break;
                case Icon.FlagBg:
                    result = "flag_bg.png";
                    break;
                case Icon.FlagBh:
                    result = "flag_bh.png";
                    break;
                case Icon.FlagBi:
                    result = "flag_bi.png";
                    break;
                case Icon.FlagBj:
                    result = "flag_bj.png";
                    break;
                case Icon.FlagBlack:
                    result = "flag_black.png";
                    break;
                case Icon.FlagBlue:
                    result = "flag_blue.png";
                    break;
                case Icon.FlagBm:
                    result = "flag_bm.png";
                    break;
                case Icon.FlagBn:
                    result = "flag_bn.png";
                    break;
                case Icon.FlagBo:
                    result = "flag_bo.png";
                    break;
                case Icon.FlagBr:
                    result = "flag_br.png";
                    break;
                case Icon.FlagBs:
                    result = "flag_bs.png";
                    break;
                case Icon.FlagBt:
                    result = "flag_bt.png";
                    break;
                case Icon.FlagBv:
                    result = "flag_bv.png";
                    break;
                case Icon.FlagBw:
                    result = "flag_bw.png";
                    break;
                case Icon.FlagBy:
                    result = "flag_by.png";
                    break;
                case Icon.FlagBz:
                    result = "flag_bz.png";
                    break;
                case Icon.FlagCa:
                    result = "flag_ca.png";
                    break;
                case Icon.FlagCatalonia:
                    result = "flag_catalonia.png";
                    break;
                case Icon.FlagCc:
                    result = "flag_cc.png";
                    break;
                case Icon.FlagCd:
                    result = "flag_cd.png";
                    break;
                case Icon.FlagCf:
                    result = "flag_cf.png";
                    break;
                case Icon.FlagCg:
                    result = "flag_cg.png";
                    break;
                case Icon.FlagCh:
                    result = "flag_ch.png";
                    break;
                case Icon.FlagChecked:
                    result = "flag_checked.png";
                    break;
                case Icon.FlagCi:
                    result = "flag_ci.png";
                    break;
                case Icon.FlagCk:
                    result = "flag_ck.png";
                    break;
                case Icon.FlagCl:
                    result = "flag_cl.png";
                    break;
                case Icon.FlagCm:
                    result = "flag_cm.png";
                    break;
                case Icon.FlagCn:
                    result = "flag_cn.png";
                    break;
                case Icon.FlagCo:
                    result = "flag_co.png";
                    break;
                case Icon.FlagCr:
                    result = "flag_cr.png";
                    break;
                case Icon.FlagCs:
                    result = "flag_cs.png";
                    break;
                case Icon.FlagCu:
                    result = "flag_cu.png";
                    break;
                case Icon.FlagCv:
                    result = "flag_cv.png";
                    break;
                case Icon.FlagCx:
                    result = "flag_cx.png";
                    break;
                case Icon.FlagCy:
                    result = "flag_cy.png";
                    break;
                case Icon.FlagCz:
                    result = "flag_cz.png";
                    break;
                case Icon.FlagDe:
                    result = "flag_de.png";
                    break;
                case Icon.FlagDj:
                    result = "flag_dj.png";
                    break;
                case Icon.FlagDk:
                    result = "flag_dk.png";
                    break;
                case Icon.FlagDm:
                    result = "flag_dm.png";
                    break;
                case Icon.FlagDo:
                    result = "flag_do.png";
                    break;
                case Icon.FlagDz:
                    result = "flag_dz.png";
                    break;
                case Icon.FlagEc:
                    result = "flag_ec.png";
                    break;
                case Icon.FlagEe:
                    result = "flag_ee.png";
                    break;
                case Icon.FlagEg:
                    result = "flag_eg.png";
                    break;
                case Icon.FlagEh:
                    result = "flag_eh.png";
                    break;
                case Icon.FlagEngland:
                    result = "flag_england.png";
                    break;
                case Icon.FlagEr:
                    result = "flag_er.png";
                    break;
                case Icon.FlagEs:
                    result = "flag_es.png";
                    break;
                case Icon.FlagEt:
                    result = "flag_et.png";
                    break;
                case Icon.FlagEuropeanunion:
                    result = "flag_europeanunion.png";
                    break;
                case Icon.FlagFam:
                    result = "flag_fam.png";
                    break;
                case Icon.FlagFi:
                    result = "flag_fi.png";
                    break;
                case Icon.FlagFj:
                    result = "flag_fj.png";
                    break;
                case Icon.FlagFk:
                    result = "flag_fk.png";
                    break;
                case Icon.FlagFm:
                    result = "flag_fm.png";
                    break;
                case Icon.FlagFo:
                    result = "flag_fo.png";
                    break;
                case Icon.FlagFr:
                    result = "flag_fr.png";
                    break;
                case Icon.FlagFrance:
                    result = "flag_france.png";
                    break;
                case Icon.FlagGa:
                    result = "flag_ga.png";
                    break;
                case Icon.FlagGb:
                    result = "flag_gb.png";
                    break;
                case Icon.FlagGd:
                    result = "flag_gd.png";
                    break;
                case Icon.FlagGe:
                    result = "flag_ge.png";
                    break;
                case Icon.FlagGf:
                    result = "flag_gf.png";
                    break;
                case Icon.FlagGg:
                    result = "flag_gg.png";
                    break;
                case Icon.FlagGh:
                    result = "flag_gh.png";
                    break;
                case Icon.FlagGi:
                    result = "flag_gi.png";
                    break;
                case Icon.FlagGl:
                    result = "flag_gl.png";
                    break;
                case Icon.FlagGm:
                    result = "flag_gm.png";
                    break;
                case Icon.FlagGn:
                    result = "flag_gn.png";
                    break;
                case Icon.FlagGp:
                    result = "flag_gp.png";
                    break;
                case Icon.FlagGq:
                    result = "flag_gq.png";
                    break;
                case Icon.FlagGr:
                    result = "flag_gr.png";
                    break;
                case Icon.FlagGreen:
                    result = "flag_green.png";
                    break;
                case Icon.FlagGrey:
                    result = "flag_grey.png";
                    break;
                case Icon.FlagGs:
                    result = "flag_gs.png";
                    break;
                case Icon.FlagGt:
                    result = "flag_gt.png";
                    break;
                case Icon.FlagGu:
                    result = "flag_gu.png";
                    break;
                case Icon.FlagGw:
                    result = "flag_gw.png";
                    break;
                case Icon.FlagGy:
                    result = "flag_gy.png";
                    break;
                case Icon.FlagHk:
                    result = "flag_hk.png";
                    break;
                case Icon.FlagHm:
                    result = "flag_hm.png";
                    break;
                case Icon.FlagHn:
                    result = "flag_hn.png";
                    break;
                case Icon.FlagHr:
                    result = "flag_hr.png";
                    break;
                case Icon.FlagHt:
                    result = "flag_ht.png";
                    break;
                case Icon.FlagHu:
                    result = "flag_hu.png";
                    break;
                case Icon.FlagId:
                    result = "flag_id.png";
                    break;
                case Icon.FlagIe:
                    result = "flag_ie.png";
                    break;
                case Icon.FlagIl:
                    result = "flag_il.png";
                    break;
                case Icon.FlagIn:
                    result = "flag_in.png";
                    break;
                case Icon.FlagIo:
                    result = "flag_io.png";
                    break;
                case Icon.FlagIq:
                    result = "flag_iq.png";
                    break;
                case Icon.FlagIr:
                    result = "flag_ir.png";
                    break;
                case Icon.FlagIs:
                    result = "flag_is.png";
                    break;
                case Icon.FlagIt:
                    result = "flag_it.png";
                    break;
                case Icon.FlagJm:
                    result = "flag_jm.png";
                    break;
                case Icon.FlagJo:
                    result = "flag_jo.png";
                    break;
                case Icon.FlagJp:
                    result = "flag_jp.png";
                    break;
                case Icon.FlagKe:
                    result = "flag_ke.png";
                    break;
                case Icon.FlagKg:
                    result = "flag_kg.png";
                    break;
                case Icon.FlagKh:
                    result = "flag_kh.png";
                    break;
                case Icon.FlagKi:
                    result = "flag_ki.png";
                    break;
                case Icon.FlagKm:
                    result = "flag_km.png";
                    break;
                case Icon.FlagKn:
                    result = "flag_kn.png";
                    break;
                case Icon.FlagKp:
                    result = "flag_kp.png";
                    break;
                case Icon.FlagKr:
                    result = "flag_kr.png";
                    break;
                case Icon.FlagKw:
                    result = "flag_kw.png";
                    break;
                case Icon.FlagKy:
                    result = "flag_ky.png";
                    break;
                case Icon.FlagKz:
                    result = "flag_kz.png";
                    break;
                case Icon.FlagLa:
                    result = "flag_la.png";
                    break;
                case Icon.FlagLb:
                    result = "flag_lb.png";
                    break;
                case Icon.FlagLc:
                    result = "flag_lc.png";
                    break;
                case Icon.FlagLi:
                    result = "flag_li.png";
                    break;
                case Icon.FlagLk:
                    result = "flag_lk.png";
                    break;
                case Icon.FlagLr:
                    result = "flag_lr.png";
                    break;
                case Icon.FlagLs:
                    result = "flag_ls.png";
                    break;
                case Icon.FlagLt:
                    result = "flag_lt.png";
                    break;
                case Icon.FlagLu:
                    result = "flag_lu.png";
                    break;
                case Icon.FlagLv:
                    result = "flag_lv.png";
                    break;
                case Icon.FlagLy:
                    result = "flag_ly.png";
                    break;
                case Icon.FlagMa:
                    result = "flag_ma.png";
                    break;
                case Icon.FlagMc:
                    result = "flag_mc.png";
                    break;
                case Icon.FlagMd:
                    result = "flag_md.png";
                    break;
                case Icon.FlagMe:
                    result = "flag_me.png";
                    break;
                case Icon.FlagMg:
                    result = "flag_mg.png";
                    break;
                case Icon.FlagMh:
                    result = "flag_mh.png";
                    break;
                case Icon.FlagMk:
                    result = "flag_mk.png";
                    break;
                case Icon.FlagMl:
                    result = "flag_ml.png";
                    break;
                case Icon.FlagMm:
                    result = "flag_mm.png";
                    break;
                case Icon.FlagMn:
                    result = "flag_mn.png";
                    break;
                case Icon.FlagMo:
                    result = "flag_mo.png";
                    break;
                case Icon.FlagMp:
                    result = "flag_mp.png";
                    break;
                case Icon.FlagMq:
                    result = "flag_mq.png";
                    break;
                case Icon.FlagMr:
                    result = "flag_mr.png";
                    break;
                case Icon.FlagMs:
                    result = "flag_ms.png";
                    break;
                case Icon.FlagMt:
                    result = "flag_mt.png";
                    break;
                case Icon.FlagMu:
                    result = "flag_mu.png";
                    break;
                case Icon.FlagMv:
                    result = "flag_mv.png";
                    break;
                case Icon.FlagMw:
                    result = "flag_mw.png";
                    break;
                case Icon.FlagMx:
                    result = "flag_mx.png";
                    break;
                case Icon.FlagMy:
                    result = "flag_my.png";
                    break;
                case Icon.FlagMz:
                    result = "flag_mz.png";
                    break;
                case Icon.FlagNa:
                    result = "flag_na.png";
                    break;
                case Icon.FlagNc:
                    result = "flag_nc.png";
                    break;
                case Icon.FlagNe:
                    result = "flag_ne.png";
                    break;
                case Icon.FlagNf:
                    result = "flag_nf.png";
                    break;
                case Icon.FlagNg:
                    result = "flag_ng.png";
                    break;
                case Icon.FlagNi:
                    result = "flag_ni.png";
                    break;
                case Icon.FlagNl:
                    result = "flag_nl.png";
                    break;
                case Icon.FlagNo:
                    result = "flag_no.png";
                    break;
                case Icon.FlagNp:
                    result = "flag_np.png";
                    break;
                case Icon.FlagNr:
                    result = "flag_nr.png";
                    break;
                case Icon.FlagNu:
                    result = "flag_nu.png";
                    break;
                case Icon.FlagNz:
                    result = "flag_nz.png";
                    break;
                case Icon.FlagOm:
                    result = "flag_om.png";
                    break;
                case Icon.FlagOrange:
                    result = "flag_orange.png";
                    break;
                case Icon.FlagPa:
                    result = "flag_pa.png";
                    break;
                case Icon.FlagPe:
                    result = "flag_pe.png";
                    break;
                case Icon.FlagPf:
                    result = "flag_pf.png";
                    break;
                case Icon.FlagPg:
                    result = "flag_pg.png";
                    break;
                case Icon.FlagPh:
                    result = "flag_ph.png";
                    break;
                case Icon.FlagPink:
                    result = "flag_pink.png";
                    break;
                case Icon.FlagPk:
                    result = "flag_pk.png";
                    break;
                case Icon.FlagPl:
                    result = "flag_pl.png";
                    break;
                case Icon.FlagPm:
                    result = "flag_pm.png";
                    break;
                case Icon.FlagPn:
                    result = "flag_pn.png";
                    break;
                case Icon.FlagPr:
                    result = "flag_pr.png";
                    break;
                case Icon.FlagPs:
                    result = "flag_ps.png";
                    break;
                case Icon.FlagPt:
                    result = "flag_pt.png";
                    break;
                case Icon.FlagPurple:
                    result = "flag_purple.png";
                    break;
                case Icon.FlagPw:
                    result = "flag_pw.png";
                    break;
                case Icon.FlagPy:
                    result = "flag_py.png";
                    break;
                case Icon.FlagQa:
                    result = "flag_qa.png";
                    break;
                case Icon.FlagRe:
                    result = "flag_re.png";
                    break;
                case Icon.FlagRed:
                    result = "flag_red.png";
                    break;
                case Icon.FlagRo:
                    result = "flag_ro.png";
                    break;
                case Icon.FlagRs:
                    result = "flag_rs.png";
                    break;
                case Icon.FlagRu:
                    result = "flag_ru.png";
                    break;
                case Icon.FlagRw:
                    result = "flag_rw.png";
                    break;
                case Icon.FlagSa:
                    result = "flag_sa.png";
                    break;
                case Icon.FlagSb:
                    result = "flag_sb.png";
                    break;
                case Icon.FlagSc:
                    result = "flag_sc.png";
                    break;
                case Icon.FlagScotland:
                    result = "flag_scotland.png";
                    break;
                case Icon.FlagSd:
                    result = "flag_sd.png";
                    break;
                case Icon.FlagSe:
                    result = "flag_se.png";
                    break;
                case Icon.FlagSg:
                    result = "flag_sg.png";
                    break;
                case Icon.FlagSh:
                    result = "flag_sh.png";
                    break;
                case Icon.FlagSi:
                    result = "flag_si.png";
                    break;
                case Icon.FlagSj:
                    result = "flag_sj.png";
                    break;
                case Icon.FlagSk:
                    result = "flag_sk.png";
                    break;
                case Icon.FlagSl:
                    result = "flag_sl.png";
                    break;
                case Icon.FlagSm:
                    result = "flag_sm.png";
                    break;
                case Icon.FlagSn:
                    result = "flag_sn.png";
                    break;
                case Icon.FlagSo:
                    result = "flag_so.png";
                    break;
                case Icon.FlagSr:
                    result = "flag_sr.png";
                    break;
                case Icon.FlagSt:
                    result = "flag_st.png";
                    break;
                case Icon.FlagSv:
                    result = "flag_sv.png";
                    break;
                case Icon.FlagSy:
                    result = "flag_sy.png";
                    break;
                case Icon.FlagSz:
                    result = "flag_sz.png";
                    break;
                case Icon.FlagTc:
                    result = "flag_tc.png";
                    break;
                case Icon.FlagTd:
                    result = "flag_td.png";
                    break;
                case Icon.FlagTf:
                    result = "flag_tf.png";
                    break;
                case Icon.FlagTg:
                    result = "flag_tg.png";
                    break;
                case Icon.FlagTh:
                    result = "flag_th.png";
                    break;
                case Icon.FlagTj:
                    result = "flag_tj.png";
                    break;
                case Icon.FlagTk:
                    result = "flag_tk.png";
                    break;
                case Icon.FlagTl:
                    result = "flag_tl.png";
                    break;
                case Icon.FlagTm:
                    result = "flag_tm.png";
                    break;
                case Icon.FlagTn:
                    result = "flag_tn.png";
                    break;
                case Icon.FlagTo:
                    result = "flag_to.png";
                    break;
                case Icon.FlagTr:
                    result = "flag_tr.png";
                    break;
                case Icon.FlagTt:
                    result = "flag_tt.png";
                    break;
                case Icon.FlagTv:
                    result = "flag_tv.png";
                    break;
                case Icon.FlagTw:
                    result = "flag_tw.png";
                    break;
                case Icon.FlagTz:
                    result = "flag_tz.png";
                    break;
                case Icon.FlagUa:
                    result = "flag_ua.png";
                    break;
                case Icon.FlagUg:
                    result = "flag_ug.png";
                    break;
                case Icon.FlagUm:
                    result = "flag_um.png";
                    break;
                case Icon.FlagUs:
                    result = "flag_us.png";
                    break;
                case Icon.FlagUy:
                    result = "flag_uy.png";
                    break;
                case Icon.FlagUz:
                    result = "flag_uz.png";
                    break;
                case Icon.FlagVa:
                    result = "flag_va.png";
                    break;
                case Icon.FlagVc:
                    result = "flag_vc.png";
                    break;
                case Icon.FlagVe:
                    result = "flag_ve.png";
                    break;
                case Icon.FlagVg:
                    result = "flag_vg.png";
                    break;
                case Icon.FlagVi:
                    result = "flag_vi.png";
                    break;
                case Icon.FlagVn:
                    result = "flag_vn.png";
                    break;
                case Icon.FlagVu:
                    result = "flag_vu.png";
                    break;
                case Icon.FlagWales:
                    result = "flag_wales.png";
                    break;
                case Icon.FlagWf:
                    result = "flag_wf.png";
                    break;
                case Icon.FlagWhite:
                    result = "flag_white.png";
                    break;
                case Icon.FlagWs:
                    result = "flag_ws.png";
                    break;
                case Icon.FlagYe:
                    result = "flag_ye.png";
                    break;
                case Icon.FlagYellow:
                    result = "flag_yellow.png";
                    break;
                case Icon.FlagYt:
                    result = "flag_yt.png";
                    break;
                case Icon.FlagZa:
                    result = "flag_za.png";
                    break;
                case Icon.FlagZm:
                    result = "flag_zm.png";
                    break;
                case Icon.FlagZw:
                    result = "flag_zw.png";
                    break;
                case Icon.FlowerDaisy:
                    result = "flower_daisy.png";
                    break;
                case Icon.Folder:
                    result = "folder.png";
                    break;
                case Icon.FolderAdd:
                    result = "folder_add.png";
                    break;
                case Icon.FolderBell:
                    result = "folder_bell.png";
                    break;
                case Icon.FolderBookmark:
                    result = "folder_bookmark.png";
                    break;
                case Icon.FolderBrick:
                    result = "folder_brick.png";
                    break;
                case Icon.FolderBug:
                    result = "folder_bug.png";
                    break;
                case Icon.FolderCamera:
                    result = "folder_camera.png";
                    break;
                case Icon.FolderConnect:
                    result = "folder_connect.png";
                    break;
                case Icon.FolderDatabase:
                    result = "folder_database.png";
                    break;
                case Icon.FolderDelete:
                    result = "folder_delete.png";
                    break;
                case Icon.FolderEdit:
                    result = "folder_edit.png";
                    break;
                case Icon.FolderError:
                    result = "folder_error.png";
                    break;
                case Icon.FolderExplore:
                    result = "folder_explore.png";
                    break;
                case Icon.FolderFeed:
                    result = "folder_feed.png";
                    break;
                case Icon.FolderFilm:
                    result = "folder_film.png";
                    break;
                case Icon.FolderFind:
                    result = "folder_find.png";
                    break;
                case Icon.FolderFont:
                    result = "folder_font.png";
                    break;
                case Icon.FolderGo:
                    result = "folder_go.png";
                    break;
                case Icon.FolderHeart:
                    result = "folder_heart.png";
                    break;
                case Icon.FolderHome:
                    result = "folder_home.png";
                    break;
                case Icon.FolderImage:
                    result = "folder_image.png";
                    break;
                case Icon.FolderKey:
                    result = "folder_key.png";
                    break;
                case Icon.FolderLightbulb:
                    result = "folder_lightbulb.png";
                    break;
                case Icon.FolderLink:
                    result = "folder_link.png";
                    break;
                case Icon.FolderMagnify:
                    result = "folder_magnify.png";
                    break;
                case Icon.FolderPage:
                    result = "folder_page.png";
                    break;
                case Icon.FolderPageWhite:
                    result = "folder_page_white.png";
                    break;
                case Icon.FolderPalette:
                    result = "folder_palette.png";
                    break;
                case Icon.FolderPicture:
                    result = "folder_picture.png";
                    break;
                case Icon.FolderStar:
                    result = "folder_star.png";
                    break;
                case Icon.FolderTable:
                    result = "folder_table.png";
                    break;
                case Icon.FolderUp:
                    result = "folder_up.png";
                    break;
                case Icon.FolderUser:
                    result = "folder_user.png";
                    break;
                case Icon.FolderWrench:
                    result = "folder_wrench.png";
                    break;
                case Icon.Font:
                    result = "font.png";
                    break;
                case Icon.FontAdd:
                    result = "font_add.png";
                    break;
                case Icon.FontColor:
                    result = "font_color.png";
                    break;
                case Icon.FontDelete:
                    result = "font_delete.png";
                    break;
                case Icon.FontGo:
                    result = "font_go.png";
                    break;
                case Icon.FontLarger:
                    result = "font_larger.png";
                    break;
                case Icon.FontSmaller:
                    result = "font_smaller.png";
                    break;
                case Icon.ForwardBlue:
                    result = "forward_blue.png";
                    break;
                case Icon.ForwardGreen:
                    result = "forward_green.png";
                    break;
                case Icon.Group:
                    result = "group.png";
                    break;
                case Icon.GroupAdd:
                    result = "group_add.png";
                    break;
                case Icon.GroupDelete:
                    result = "group_delete.png";
                    break;
                case Icon.GroupEdit:
                    result = "group_edit.png";
                    break;
                case Icon.GroupError:
                    result = "group_error.png";
                    break;
                case Icon.GroupGear:
                    result = "group_gear.png";
                    break;
                case Icon.GroupGo:
                    result = "group_go.png";
                    break;
                case Icon.GroupKey:
                    result = "group_key.png";
                    break;
                case Icon.GroupLink:
                    result = "group_link.png";
                    break;
                case Icon.Heart:
                    result = "heart.png";
                    break;
                case Icon.HeartAdd:
                    result = "heart_add.png";
                    break;
                case Icon.HeartBroken:
                    result = "heart_broken.png";
                    break;
                case Icon.HeartConnect:
                    result = "heart_connect.png";
                    break;
                case Icon.HeartDelete:
                    result = "heart_delete.png";
                    break;
                case Icon.Help:
                    result = "help.png";
                    break;
                case Icon.Hourglass:
                    result = "hourglass.png";
                    break;
                case Icon.HourglassAdd:
                    result = "hourglass_add.png";
                    break;
                case Icon.HourglassDelete:
                    result = "hourglass_delete.png";
                    break;
                case Icon.HourglassGo:
                    result = "hourglass_go.png";
                    break;
                case Icon.HourglassLink:
                    result = "hourglass_link.png";
                    break;
                case Icon.House:
                    result = "house.png";
                    break;
                case Icon.HouseConnect:
                    result = "house_connect.png";
                    break;
                case Icon.HouseGo:
                    result = "house_go.png";
                    break;
                case Icon.HouseKey:
                    result = "house_key.png";
                    break;
                case Icon.HouseLink:
                    result = "house_link.png";
                    break;
                case Icon.HouseStar:
                    result = "house_star.png";
                    break;
                case Icon.Html:
                    result = "html.png";
                    break;
                case Icon.HtmlAdd:
                    result = "html_add.png";
                    break;
                case Icon.HtmlDelete:
                    result = "html_delete.png";
                    break;
                case Icon.HtmlError:
                    result = "html_error.png";
                    break;
                case Icon.HtmlGo:
                    result = "html_go.png";
                    break;
                case Icon.HtmlValid:
                    result = "html_valid.png";
                    break;
                case Icon.Image:
                    result = "image.png";
                    break;
                case Icon.Images:
                    result = "images.png";
                    break;
                case Icon.ImageAdd:
                    result = "image_add.png";
                    break;
                case Icon.ImageDelete:
                    result = "image_delete.png";
                    break;
                case Icon.ImageEdit:
                    result = "image_edit.png";
                    break;
                case Icon.ImageLink:
                    result = "image_link.png";
                    break;
                case Icon.ImageMagnify:
                    result = "image_magnify.png";
                    break;
                case Icon.ImageStar:
                    result = "image_star.png";
                    break;
                case Icon.Information:
                    result = "information.png";
                    break;
                case Icon.Ipod:
                    result = "ipod.png";
                    break;
                case Icon.IpodCast:
                    result = "ipod_cast.png";
                    break;
                case Icon.IpodCastAdd:
                    result = "ipod_cast_add.png";
                    break;
                case Icon.IpodCastDelete:
                    result = "ipod_cast_delete.png";
                    break;
                case Icon.IpodConnect:
                    result = "ipod_connect.png";
                    break;
                case Icon.IpodNano:
                    result = "ipod_nano.png";
                    break;
                case Icon.IpodNanoConnect:
                    result = "ipod_nano_connect.png";
                    break;
                case Icon.IpodSound:
                    result = "ipod_sound.png";
                    break;
                case Icon.Joystick:
                    result = "joystick.png";
                    break;
                case Icon.JoystickAdd:
                    result = "joystick_add.png";
                    break;
                case Icon.JoystickConnect:
                    result = "joystick_connect.png";
                    break;
                case Icon.JoystickDelete:
                    result = "joystick_delete.png";
                    break;
                case Icon.JoystickError:
                    result = "joystick_error.png";
                    break;
                case Icon.Key:
                    result = "key.png";
                    break;
                case Icon.Keyboard:
                    result = "keyboard.png";
                    break;
                case Icon.KeyboardAdd:
                    result = "keyboard_add.png";
                    break;
                case Icon.KeyboardConnect:
                    result = "keyboard_connect.png";
                    break;
                case Icon.KeyboardDelete:
                    result = "keyboard_delete.png";
                    break;
                case Icon.KeyboardMagnify:
                    result = "keyboard_magnify.png";
                    break;
                case Icon.KeyAdd:
                    result = "key_add.png";
                    break;
                case Icon.KeyDelete:
                    result = "key_delete.png";
                    break;
                case Icon.KeyGo:
                    result = "key_go.png";
                    break;
                case Icon.KeyStart:
                    result = "key_start.png";
                    break;
                case Icon.KeyStop:
                    result = "key_stop.png";
                    break;
                case Icon.Laptop:
                    result = "laptop.png";
                    break;
                case Icon.LaptopAdd:
                    result = "laptop_add.png";
                    break;
                case Icon.LaptopConnect:
                    result = "laptop_connect.png";
                    break;
                case Icon.LaptopDelete:
                    result = "laptop_delete.png";
                    break;
                case Icon.LaptopDisk:
                    result = "laptop_disk.png";
                    break;
                case Icon.LaptopEdit:
                    result = "laptop_edit.png";
                    break;
                case Icon.LaptopError:
                    result = "laptop_error.png";
                    break;
                case Icon.LaptopGo:
                    result = "laptop_go.png";
                    break;
                case Icon.LaptopKey:
                    result = "laptop_key.png";
                    break;
                case Icon.LaptopLink:
                    result = "laptop_link.png";
                    break;
                case Icon.LaptopMagnify:
                    result = "laptop_magnify.png";
                    break;
                case Icon.LaptopStart:
                    result = "laptop_start.png";
                    break;
                case Icon.LaptopStop:
                    result = "laptop_stop.png";
                    break;
                case Icon.LaptopWrench:
                    result = "laptop_wrench.png";
                    break;
                case Icon.Layers:
                    result = "layers.png";
                    break;
                case Icon.Layout:
                    result = "layout.png";
                    break;
                case Icon.LayoutAdd:
                    result = "layout_add.png";
                    break;
                case Icon.LayoutContent:
                    result = "layout_content.png";
                    break;
                case Icon.LayoutDelete:
                    result = "layout_delete.png";
                    break;
                case Icon.LayoutEdit:
                    result = "layout_edit.png";
                    break;
                case Icon.LayoutError:
                    result = "layout_error.png";
                    break;
                case Icon.LayoutHeader:
                    result = "layout_header.png";
                    break;
                case Icon.LayoutKey:
                    result = "layout_key.png";
                    break;
                case Icon.LayoutLightning:
                    result = "layout_lightning.png";
                    break;
                case Icon.LayoutLink:
                    result = "layout_link.png";
                    break;
                case Icon.LayoutSidebar:
                    result = "layout_sidebar.png";
                    break;
                case Icon.Lightbulb:
                    result = "lightbulb.png";
                    break;
                case Icon.LightbulbAdd:
                    result = "lightbulb_add.png";
                    break;
                case Icon.LightbulbDelete:
                    result = "lightbulb_delete.png";
                    break;
                case Icon.LightbulbOff:
                    result = "lightbulb_off.png";
                    break;
                case Icon.Lightning:
                    result = "lightning.png";
                    break;
                case Icon.LightningAdd:
                    result = "lightning_add.png";
                    break;
                case Icon.LightningDelete:
                    result = "lightning_delete.png";
                    break;
                case Icon.LightningGo:
                    result = "lightning_go.png";
                    break;
                case Icon.Link:
                    result = "link.png";
                    break;
                case Icon.LinkAdd:
                    result = "link_add.png";
                    break;
                case Icon.LinkBreak:
                    result = "link_break.png";
                    break;
                case Icon.LinkDelete:
                    result = "link_delete.png";
                    break;
                case Icon.LinkEdit:
                    result = "link_edit.png";
                    break;
                case Icon.LinkError:
                    result = "link_error.png";
                    break;
                case Icon.LinkGo:
                    result = "link_go.png";
                    break;
                case Icon.Lock:
                    result = "lock.png";
                    break;
                case Icon.LockAdd:
                    result = "lock_add.png";
                    break;
                case Icon.LockBreak:
                    result = "lock_break.png";
                    break;
                case Icon.LockDelete:
                    result = "lock_delete.png";
                    break;
                case Icon.LockEdit:
                    result = "lock_edit.png";
                    break;
                case Icon.LockGo:
                    result = "lock_go.png";
                    break;
                case Icon.LockKey:
                    result = "lock_key.png";
                    break;
                case Icon.LockOpen:
                    result = "lock_open.png";
                    break;
                case Icon.LockStart:
                    result = "lock_start.png";
                    break;
                case Icon.LockStop:
                    result = "lock_stop.png";
                    break;
                case Icon.Lorry:
                    result = "lorry.png";
                    break;
                case Icon.LorryAdd:
                    result = "lorry_add.png";
                    break;
                case Icon.LorryDelete:
                    result = "lorry_delete.png";
                    break;
                case Icon.LorryError:
                    result = "lorry_error.png";
                    break;
                case Icon.LorryFlatbed:
                    result = "lorry_flatbed.png";
                    break;
                case Icon.LorryGo:
                    result = "lorry_go.png";
                    break;
                case Icon.LorryLink:
                    result = "lorry_link.png";
                    break;
                case Icon.LorryStart:
                    result = "lorry_start.png";
                    break;
                case Icon.LorryStop:
                    result = "lorry_stop.png";
                    break;
                case Icon.MagifierZoomOut:
                    result = "magifier_zoom_out.png";
                    break;
                case Icon.Magnifier:
                    result = "magnifier.png";
                    break;
                case Icon.MagnifierZoomIn:
                    result = "magnifier_zoom_in.png";
                    break;
                case Icon.Mail:
                    result = "mail.png";
                    break;
                case Icon.Male:
                    result = "male.png";
                    break;
                case Icon.Map:
                    result = "map.png";
                    break;
                case Icon.MapAdd:
                    result = "map_add.png";
                    break;
                case Icon.MapClipboard:
                    result = "map_clipboard.png";
                    break;
                case Icon.MapCursor:
                    result = "map_cursor.png";
                    break;
                case Icon.MapDelete:
                    result = "map_delete.png";
                    break;
                case Icon.MapEdit:
                    result = "map_edit.png";
                    break;
                case Icon.MapError:
                    result = "map_error.png";
                    break;
                case Icon.MapGo:
                    result = "map_go.png";
                    break;
                case Icon.MapLink:
                    result = "map_link.png";
                    break;
                case Icon.MapMagnify:
                    result = "map_magnify.png";
                    break;
                case Icon.MapStart:
                    result = "map_start.png";
                    break;
                case Icon.MapStop:
                    result = "map_stop.png";
                    break;
                case Icon.MedalBronze1:
                    result = "medal_bronze_1.png";
                    break;
                case Icon.MedalBronze2:
                    result = "medal_bronze_2.png";
                    break;
                case Icon.MedalBronze3:
                    result = "medal_bronze_3.png";
                    break;
                case Icon.MedalBronzeAdd:
                    result = "medal_bronze_add.png";
                    break;
                case Icon.MedalBronzeDelete:
                    result = "medal_bronze_delete.png";
                    break;
                case Icon.MedalGold1:
                    result = "medal_gold_1.png";
                    break;
                case Icon.MedalGold2:
                    result = "medal_gold_2.png";
                    break;
                case Icon.MedalGold3:
                    result = "medal_gold_3.png";
                    break;
                case Icon.MedalGoldAdd:
                    result = "medal_gold_add.png";
                    break;
                case Icon.MedalGoldDelete:
                    result = "medal_gold_delete.png";
                    break;
                case Icon.MedalSilver1:
                    result = "medal_silver_1.png";
                    break;
                case Icon.MedalSilver2:
                    result = "medal_silver_2.png";
                    break;
                case Icon.MedalSilver3:
                    result = "medal_silver_3.png";
                    break;
                case Icon.MedalSilverAdd:
                    result = "medal_silver_add.png";
                    break;
                case Icon.MedalSilverDelete:
                    result = "medal_silver_delete.png";
                    break;
                case Icon.Money:
                    result = "money.png";
                    break;
                case Icon.MoneyAdd:
                    result = "money_add.png";
                    break;
                case Icon.MoneyDelete:
                    result = "money_delete.png";
                    break;
                case Icon.MoneyDollar:
                    result = "money_dollar.png";
                    break;
                case Icon.MoneyEuro:
                    result = "money_euro.png";
                    break;
                case Icon.MoneyPound:
                    result = "money_pound.png";
                    break;
                case Icon.MoneyYen:
                    result = "money_yen.png";
                    break;
                case Icon.Monitor:
                    result = "monitor.png";
                    break;
                case Icon.MonitorAdd:
                    result = "monitor_add.png";
                    break;
                case Icon.MonitorDelete:
                    result = "monitor_delete.png";
                    break;
                case Icon.MonitorEdit:
                    result = "monitor_edit.png";
                    break;
                case Icon.MonitorError:
                    result = "monitor_error.png";
                    break;
                case Icon.MonitorGo:
                    result = "monitor_go.png";
                    break;
                case Icon.MonitorKey:
                    result = "monitor_key.png";
                    break;
                case Icon.MonitorLightning:
                    result = "monitor_lightning.png";
                    break;
                case Icon.MonitorLink:
                    result = "monitor_link.png";
                    break;
                case Icon.MoonFull:
                    result = "moon_full.png";
                    break;
                case Icon.Mouse:
                    result = "mouse.png";
                    break;
                case Icon.MouseAdd:
                    result = "mouse_add.png";
                    break;
                case Icon.MouseDelete:
                    result = "mouse_delete.png";
                    break;
                case Icon.MouseError:
                    result = "mouse_error.png";
                    break;
                case Icon.Music:
                    result = "music.png";
                    break;
                case Icon.MusicNote:
                    result = "music_note.png";
                    break;
                case Icon.Neighbourhood:
                    result = "neighbourhood.png";
                    break;
                case Icon.New:
                    result = "new.png";
                    break;
                case Icon.Newspaper:
                    result = "newspaper.png";
                    break;
                case Icon.NewspaperAdd:
                    result = "newspaper_add.png";
                    break;
                case Icon.NewspaperDelete:
                    result = "newspaper_delete.png";
                    break;
                case Icon.NewspaperGo:
                    result = "newspaper_go.png";
                    break;
                case Icon.NewspaperLink:
                    result = "newspaper_link.png";
                    break;
                case Icon.NewBlue:
                    result = "new_blue.png";
                    break;
                case Icon.NewRed:
                    result = "new_red.png";
                    break;
                case Icon.NextBlue:
                    result = "next_blue.png";
                    break;
                case Icon.NextGreen:
                    result = "next_green.png";
                    break;
                case Icon.Note:
                    result = "note.png";
                    break;
                case Icon.NoteAdd:
                    result = "note_add.png";
                    break;
                case Icon.NoteDelete:
                    result = "note_delete.png";
                    break;
                case Icon.NoteEdit:
                    result = "note_edit.png";
                    break;
                case Icon.NoteError:
                    result = "note_error.png";
                    break;
                case Icon.NoteGo:
                    result = "note_go.png";
                    break;
                case Icon.Outline:
                    result = "outline.png";
                    break;
                case Icon.Overlays:
                    result = "overlays.png";
                    break;
                case Icon.Package:
                    result = "package.png";
                    break;
                case Icon.PackageAdd:
                    result = "package_add.png";
                    break;
                case Icon.PackageDelete:
                    result = "package_delete.png";
                    break;
                case Icon.PackageDown:
                    result = "package_down.png";
                    break;
                case Icon.PackageGo:
                    result = "package_go.png";
                    break;
                case Icon.PackageGreen:
                    result = "package_green.png";
                    break;
                case Icon.PackageIn:
                    result = "package_in.png";
                    break;
                case Icon.PackageLink:
                    result = "package_link.png";
                    break;
                case Icon.PackageSe:
                    result = "package_se.png";
                    break;
                case Icon.PackageStart:
                    result = "package_start.png";
                    break;
                case Icon.PackageStop:
                    result = "package_stop.png";
                    break;
                case Icon.PackageWhite:
                    result = "package_white.png";
                    break;
                case Icon.Page:
                    result = "page.png";
                    break;
                case Icon.PageAdd:
                    result = "page_add.png";
                    break;
                case Icon.PageAttach:
                    result = "page_attach.png";
                    break;
                case Icon.PageBack:
                    result = "page_back.png";
                    break;
                case Icon.PageBreak:
                    result = "page_break.png";
                    break;
                case Icon.PageBreakInsert:
                    result = "page_break_insert.png";
                    break;
                case Icon.PageCancel:
                    result = "page_cancel.png";
                    break;
                case Icon.PageCode:
                    result = "page_code.png";
                    break;
                case Icon.PageCopy:
                    result = "page_copy.png";
                    break;
                case Icon.PageDelete:
                    result = "page_delete.png";
                    break;
                case Icon.PageEdit:
                    result = "page_edit.png";
                    break;
                case Icon.PageError:
                    result = "page_error.png";
                    break;
                case Icon.PageExcel:
                    result = "page_excel.png";
                    break;
                case Icon.PageFind:
                    result = "page_find.png";
                    break;
                case Icon.PageForward:
                    result = "page_forward.png";
                    break;
                case Icon.PageGear:
                    result = "page_gear.png";
                    break;
                case Icon.PageGo:
                    result = "page_go.png";
                    break;
                case Icon.PageGreen:
                    result = "page_green.png";
                    break;
                case Icon.PageHeaderFooter:
                    result = "page_header_footer.png";
                    break;
                case Icon.PageKey:
                    result = "page_key.png";
                    break;
                case Icon.PageLandscape:
                    result = "page_landscape.png";
                    break;
                case Icon.PageLandscapeShot:
                    result = "page_landscape_shot.png";
                    break;
                case Icon.PageLightning:
                    result = "page_lightning.png";
                    break;
                case Icon.PageLink:
                    result = "page_link.png";
                    break;
                case Icon.PageMagnify:
                    result = "page_magnify.png";
                    break;
                case Icon.PagePaintbrush:
                    result = "page_paintbrush.png";
                    break;
                case Icon.PagePaste:
                    result = "page_paste.png";
                    break;
                case Icon.PagePortrait:
                    result = "page_portrait.png";
                    break;
                case Icon.PagePortraitShot:
                    result = "page_portrait_shot.png";
                    break;
                case Icon.PageRed:
                    result = "page_red.png";
                    break;
                case Icon.PageRefresh:
                    result = "page_refresh.png";
                    break;
                case Icon.PageSave:
                    result = "page_save.png";
                    break;
                case Icon.PageWhite:
                    result = "page_white.png";
                    break;
                case Icon.PageWhiteAcrobat:
                    result = "page_white_acrobat.png";
                    break;
                case Icon.PageWhiteActionscript:
                    result = "page_white_actionscript.png";
                    break;
                case Icon.PageWhiteAdd:
                    result = "page_white_add.png";
                    break;
                case Icon.PageWhiteBreak:
                    result = "page_white_break.png";
                    break;
                case Icon.PageWhiteC:
                    result = "page_white_c.png";
                    break;
                case Icon.PageWhiteCamera:
                    result = "page_white_camera.png";
                    break;
                case Icon.PageWhiteCd:
                    result = "page_white_cd.png";
                    break;
                case Icon.PageWhiteCdr:
                    result = "page_white_cdr.png";
                    break;
                case Icon.PageWhiteCode:
                    result = "page_white_code.png";
                    break;
                case Icon.PageWhiteCodeRed:
                    result = "page_white_code_red.png";
                    break;
                case Icon.PageWhiteColdfusion:
                    result = "page_white_coldfusion.png";
                    break;
                case Icon.PageWhiteCompressed:
                    result = "page_white_compressed.png";
                    break;
                case Icon.PageWhiteConnect:
                    result = "page_white_connect.png";
                    break;
                case Icon.PageWhiteCopy:
                    result = "page_white_copy.png";
                    break;
                case Icon.PageWhiteCplusplus:
                    result = "page_white_cplusplus.png";
                    break;
                case Icon.PageWhiteCsharp:
                    result = "page_white_csharp.png";
                    break;
                case Icon.PageWhiteCup:
                    result = "page_white_cup.png";
                    break;
                case Icon.PageWhiteDatabase:
                    result = "page_white_database.png";
                    break;
                case Icon.PageWhiteDatabaseYellow:
                    result = "page_white_database_yellow.png";
                    break;
                case Icon.PageWhiteDelete:
                    result = "page_white_delete.png";
                    break;
                case Icon.PageWhiteDvd:
                    result = "page_white_dvd.png";
                    break;
                case Icon.PageWhiteEdit:
                    result = "page_white_edit.png";
                    break;
                case Icon.PageWhiteError:
                    result = "page_white_error.png";
                    break;
                case Icon.PageWhiteExcel:
                    result = "page_white_excel.png";
                    break;
                case Icon.PageWhiteFind:
                    result = "page_white_find.png";
                    break;
                case Icon.PageWhiteFlash:
                    result = "page_white_flash.png";
                    break;
                case Icon.PageWhiteFont:
                    result = "page_white_font.png";
                    break;
                case Icon.PageWhiteFreehand:
                    result = "page_white_freehand.png";
                    break;
                case Icon.PageWhiteGear:
                    result = "page_white_gear.png";
                    break;
                case Icon.PageWhiteGet:
                    result = "page_white_get.png";
                    break;
                case Icon.PageWhiteGo:
                    result = "page_white_go.png";
                    break;
                case Icon.PageWhiteH:
                    result = "page_white_h.png";
                    break;
                case Icon.PageWhiteHorizontal:
                    result = "page_white_horizontal.png";
                    break;
                case Icon.PageWhiteKey:
                    result = "page_white_key.png";
                    break;
                case Icon.PageWhiteLightning:
                    result = "page_white_lightning.png";
                    break;
                case Icon.PageWhiteLink:
                    result = "page_white_link.png";
                    break;
                case Icon.PageWhiteMagnify:
                    result = "page_white_magnify.png";
                    break;
                case Icon.PageWhiteMedal:
                    result = "page_white_medal.png";
                    break;
                case Icon.PageWhiteOffice:
                    result = "page_white_office.png";
                    break;
                case Icon.PageWhitePaint:
                    result = "page_white_paint.png";
                    break;
                case Icon.PageWhitePaintbrush:
                    result = "page_white_paintbrush.png";
                    break;
                case Icon.PageWhitePaint2:
                    result = "page_white_paint_2.png";
                    break;
                case Icon.PageWhitePaste:
                    result = "page_white_paste.png";
                    break;
                case Icon.PageWhitePasteTable:
                    result = "page_white_paste_table.png";
                    break;
                case Icon.PageWhitePhp:
                    result = "page_white_php.png";
                    break;
                case Icon.PageWhitePicture:
                    result = "page_white_picture.png";
                    break;
                case Icon.PageWhitePowerpoint:
                    result = "page_white_powerpoint.png";
                    break;
                case Icon.PageWhitePut:
                    result = "page_white_put.png";
                    break;
                case Icon.PageWhiteRefresh:
                    result = "page_white_refresh.png";
                    break;
                case Icon.PageWhiteRuby:
                    result = "page_white_ruby.png";
                    break;
                case Icon.PageWhiteSideBySide:
                    result = "page_white_side_by_side.png";
                    break;
                case Icon.PageWhiteStack:
                    result = "page_white_stack.png";
                    break;
                case Icon.PageWhiteStar:
                    result = "page_white_star.png";
                    break;
                case Icon.PageWhiteSwoosh:
                    result = "page_white_swoosh.png";
                    break;
                case Icon.PageWhiteText:
                    result = "page_white_text.png";
                    break;
                case Icon.PageWhiteTextWidth:
                    result = "page_white_text_width.png";
                    break;
                case Icon.PageWhiteTux:
                    result = "page_white_tux.png";
                    break;
                case Icon.PageWhiteVector:
                    result = "page_white_vector.png";
                    break;
                case Icon.PageWhiteVisualstudio:
                    result = "page_white_visualstudio.png";
                    break;
                case Icon.PageWhiteWidth:
                    result = "page_white_width.png";
                    break;
                case Icon.PageWhiteWord:
                    result = "page_white_word.png";
                    break;
                case Icon.PageWhiteWorld:
                    result = "page_white_world.png";
                    break;
                case Icon.PageWhiteWrench:
                    result = "page_white_wrench.png";
                    break;
                case Icon.PageWhiteZip:
                    result = "page_white_zip.png";
                    break;
                case Icon.PageWord:
                    result = "page_word.png";
                    break;
                case Icon.PageWorld:
                    result = "page_world.png";
                    break;
                case Icon.Paint:
                    result = "paint.png";
                    break;
                case Icon.Paintbrush:
                    result = "paintbrush.png";
                    break;
                case Icon.PaintbrushColor:
                    result = "paintbrush_color.png";
                    break;
                case Icon.Paintcan:
                    result = "paintcan.png";
                    break;
                case Icon.PaintcanRed:
                    result = "paintcan_red.png";
                    break;
                case Icon.PaintCanBrush:
                    result = "paint_can_brush.png";
                    break;
                case Icon.Palette:
                    result = "palette.png";
                    break;
                case Icon.PastePlain:
                    result = "paste_plain.png";
                    break;
                case Icon.PasteWord:
                    result = "paste_word.png";
                    break;
                case Icon.PauseBlue:
                    result = "pause_blue.png";
                    break;
                case Icon.PauseGreen:
                    result = "pause_green.png";
                    break;
                case Icon.PauseRecord:
                    result = "pause_record.png";
                    break;
                case Icon.Pencil:
                    result = "pencil.png";
                    break;
                case Icon.PencilAdd:
                    result = "pencil_add.png";
                    break;
                case Icon.PencilDelete:
                    result = "pencil_delete.png";
                    break;
                case Icon.PencilGo:
                    result = "pencil_go.png";
                    break;
                case Icon.Phone:
                    result = "phone.png";
                    break;
                case Icon.PhoneAdd:
                    result = "phone_add.png";
                    break;
                case Icon.PhoneDelete:
                    result = "phone_delete.png";
                    break;
                case Icon.PhoneEdit:
                    result = "phone_edit.png";
                    break;
                case Icon.PhoneError:
                    result = "phone_error.png";
                    break;
                case Icon.PhoneGo:
                    result = "phone_go.png";
                    break;
                case Icon.PhoneKey:
                    result = "phone_key.png";
                    break;
                case Icon.PhoneLink:
                    result = "phone_link.png";
                    break;
                case Icon.PhoneSound:
                    result = "phone_sound.png";
                    break;
                case Icon.PhoneStart:
                    result = "phone_start.png";
                    break;
                case Icon.PhoneStop:
                    result = "phone_stop.png";
                    break;
                case Icon.Photo:
                    result = "photo.png";
                    break;
                case Icon.Photos:
                    result = "photos.png";
                    break;
                case Icon.PhotoAdd:
                    result = "photo_add.png";
                    break;
                case Icon.PhotoDelete:
                    result = "photo_delete.png";
                    break;
                case Icon.PhotoEdit:
                    result = "photo_edit.png";
                    break;
                case Icon.PhotoLink:
                    result = "photo_link.png";
                    break;
                case Icon.PhotoPaint:
                    result = "photo_paint.png";
                    break;
                case Icon.Picture:
                    result = "picture.png";
                    break;
                case Icon.Pictures:
                    result = "pictures.png";
                    break;
                case Icon.PicturesThumbs:
                    result = "pictures_thumbs.png";
                    break;
                case Icon.PictureAdd:
                    result = "picture_add.png";
                    break;
                case Icon.PictureClipboard:
                    result = "picture_clipboard.png";
                    break;
                case Icon.PictureDelete:
                    result = "picture_delete.png";
                    break;
                case Icon.PictureEdit:
                    result = "picture_edit.png";
                    break;
                case Icon.PictureEmpty:
                    result = "picture_empty.png";
                    break;
                case Icon.PictureError:
                    result = "picture_error.png";
                    break;
                case Icon.PictureGo:
                    result = "picture_go.png";
                    break;
                case Icon.PictureKey:
                    result = "picture_key.png";
                    break;
                case Icon.PictureLink:
                    result = "picture_link.png";
                    break;
                case Icon.PictureSave:
                    result = "picture_save.png";
                    break;
                case Icon.Pilcrow:
                    result = "pilcrow.png";
                    break;
                case Icon.Pill:
                    result = "pill.png";
                    break;
                case Icon.PillAdd:
                    result = "pill_add.png";
                    break;
                case Icon.PillDelete:
                    result = "pill_delete.png";
                    break;
                case Icon.PillError:
                    result = "pill_error.png";
                    break;
                case Icon.PillGo:
                    result = "pill_go.png";
                    break;
                case Icon.PlayBlue:
                    result = "play_blue.png";
                    break;
                case Icon.PlayGreen:
                    result = "play_green.png";
                    break;
                case Icon.Plugin:
                    result = "plugin.png";
                    break;
                case Icon.PluginAdd:
                    result = "plugin_add.png";
                    break;
                case Icon.PluginDelete:
                    result = "plugin_delete.png";
                    break;
                case Icon.PluginDisabled:
                    result = "plugin_disabled.png";
                    break;
                case Icon.PluginEdit:
                    result = "plugin_edit.png";
                    break;
                case Icon.PluginError:
                    result = "plugin_error.png";
                    break;
                case Icon.PluginGo:
                    result = "plugin_go.png";
                    break;
                case Icon.PluginKey:
                    result = "plugin_key.png";
                    break;
                case Icon.PluginLink:
                    result = "plugin_link.png";
                    break;
                case Icon.PreviousGreen:
                    result = "previous_green.png";
                    break;
                case Icon.Printer:
                    result = "printer.png";
                    break;
                case Icon.PrinterAdd:
                    result = "printer_add.png";
                    break;
                case Icon.PrinterCancel:
                    result = "printer_cancel.png";
                    break;
                case Icon.PrinterColor:
                    result = "printer_color.png";
                    break;
                case Icon.PrinterConnect:
                    result = "printer_connect.png";
                    break;
                case Icon.PrinterDelete:
                    result = "printer_delete.png";
                    break;
                case Icon.PrinterEmpty:
                    result = "printer_empty.png";
                    break;
                case Icon.PrinterError:
                    result = "printer_error.png";
                    break;
                case Icon.PrinterGo:
                    result = "printer_go.png";
                    break;
                case Icon.PrinterKey:
                    result = "printer_key.png";
                    break;
                case Icon.PrinterMono:
                    result = "printer_mono.png";
                    break;
                case Icon.PrinterStart:
                    result = "printer_start.png";
                    break;
                case Icon.PrinterStop:
                    result = "printer_stop.png";
                    break;
                case Icon.Rainbow:
                    result = "rainbow.png";
                    break;
                case Icon.RainbowStar:
                    result = "rainbow_star.png";
                    break;
                case Icon.RecordBlue:
                    result = "record_blue.png";
                    break;
                case Icon.RecordGreen:
                    result = "record_green.png";
                    break;
                case Icon.RecordRed:
                    result = "record_red.png";
                    break;
                case Icon.Reload:
                    result = "reload.png";
                    break;
                case Icon.Report:
                    result = "report.png";
                    break;
                case Icon.ReportAdd:
                    result = "report_add.png";
                    break;
                case Icon.ReportDelete:
                    result = "report_delete.png";
                    break;
                case Icon.ReportDisk:
                    result = "report_disk.png";
                    break;
                case Icon.ReportEdit:
                    result = "report_edit.png";
                    break;
                case Icon.ReportGo:
                    result = "report_go.png";
                    break;
                case Icon.ReportKey:
                    result = "report_key.png";
                    break;
                case Icon.ReportLink:
                    result = "report_link.png";
                    break;
                case Icon.ReportMagnify:
                    result = "report_magnify.png";
                    break;
                case Icon.ReportPicture:
                    result = "report_picture.png";
                    break;
                case Icon.ReportStart:
                    result = "report_start.png";
                    break;
                case Icon.ReportStop:
                    result = "report_stop.png";
                    break;
                case Icon.ReportUser:
                    result = "report_user.png";
                    break;
                case Icon.ReportWord:
                    result = "report_word.png";
                    break;
                case Icon.ResultsetFirst:
                    result = "resultset_first.png";
                    break;
                case Icon.ResultsetLast:
                    result = "resultset_last.png";
                    break;
                case Icon.ResultsetNext:
                    result = "resultset_next.png";
                    break;
                case Icon.ResultsetPrevious:
                    result = "resultset_previous.png";
                    break;
                case Icon.ReverseBlue:
                    result = "reverse_blue.png";
                    break;
                case Icon.ReverseGreen:
                    result = "reverse_green.png";
                    break;
                case Icon.RewindBlue:
                    result = "rewind_blue.png";
                    break;
                case Icon.RewindGreen:
                    result = "rewind_green.png";
                    break;
                case Icon.Rgb:
                    result = "rgb.png";
                    break;
                case Icon.Rosette:
                    result = "rosette.png";
                    break;
                case Icon.RosetteBlue:
                    result = "rosette_blue.png";
                    break;
                case Icon.Rss:
                    result = "rss.png";
                    break;
                case Icon.RssAdd:
                    result = "rss_add.png";
                    break;
                case Icon.RssDelete:
                    result = "rss_delete.png";
                    break;
                case Icon.RssError:
                    result = "rss_error.png";
                    break;
                case Icon.RssGo:
                    result = "rss_go.png";
                    break;
                case Icon.RssValid:
                    result = "rss_valid.png";
                    break;
                case Icon.Ruby:
                    result = "ruby.png";
                    break;
                case Icon.RubyAdd:
                    result = "ruby_add.png";
                    break;
                case Icon.RubyDelete:
                    result = "ruby_delete.png";
                    break;
                case Icon.RubyGear:
                    result = "ruby_gear.png";
                    break;
                case Icon.RubyGet:
                    result = "ruby_get.png";
                    break;
                case Icon.RubyGo:
                    result = "ruby_go.png";
                    break;
                case Icon.RubyKey:
                    result = "ruby_key.png";
                    break;
                case Icon.RubyLink:
                    result = "ruby_link.png";
                    break;
                case Icon.RubyPut:
                    result = "ruby_put.png";
                    break;
                case Icon.Script:
                    result = "script.png";
                    break;
                case Icon.ScriptAdd:
                    result = "script_add.png";
                    break;
                case Icon.ScriptCode:
                    result = "script_code.png";
                    break;
                case Icon.ScriptCodeOriginal:
                    result = "script_code_original.png";
                    break;
                case Icon.ScriptCodeRed:
                    result = "script_code_red.png";
                    break;
                case Icon.ScriptDelete:
                    result = "script_delete.png";
                    break;
                case Icon.ScriptEdit:
                    result = "script_edit.png";
                    break;
                case Icon.ScriptError:
                    result = "script_error.png";
                    break;
                case Icon.ScriptGear:
                    result = "script_gear.png";
                    break;
                case Icon.ScriptGo:
                    result = "script_go.png";
                    break;
                case Icon.ScriptKey:
                    result = "script_key.png";
                    break;
                case Icon.ScriptLightning:
                    result = "script_lightning.png";
                    break;
                case Icon.ScriptLink:
                    result = "script_link.png";
                    break;
                case Icon.ScriptPalette:
                    result = "script_palette.png";
                    break;
                case Icon.ScriptSave:
                    result = "script_save.png";
                    break;
                case Icon.ScriptStart:
                    result = "script_start.png";
                    break;
                case Icon.ScriptStop:
                    result = "script_stop.png";
                    break;
                case Icon.Seasons:
                    result = "seasons.png";
                    break;
                case Icon.SectionCollapsed:
                    result = "section_collapsed.png";
                    break;
                case Icon.SectionExpanded:
                    result = "section_expanded.png";
                    break;
                case Icon.Server:
                    result = "server.png";
                    break;
                case Icon.ServerAdd:
                    result = "server_add.png";
                    break;
                case Icon.ServerChart:
                    result = "server_chart.png";
                    break;
                case Icon.ServerCompressed:
                    result = "server_compressed.png";
                    break;
                case Icon.ServerConnect:
                    result = "server_connect.png";
                    break;
                case Icon.ServerDatabase:
                    result = "server_database.png";
                    break;
                case Icon.ServerDelete:
                    result = "server_delete.png";
                    break;
                case Icon.ServerEdit:
                    result = "server_edit.png";
                    break;
                case Icon.ServerError:
                    result = "server_error.png";
                    break;
                case Icon.ServerGo:
                    result = "server_go.png";
                    break;
                case Icon.ServerKey:
                    result = "server_key.png";
                    break;
                case Icon.ServerLightning:
                    result = "server_lightning.png";
                    break;
                case Icon.ServerLink:
                    result = "server_link.png";
                    break;
                case Icon.ServerStart:
                    result = "server_start.png";
                    break;
                case Icon.ServerStop:
                    result = "server_stop.png";
                    break;
                case Icon.ServerUncompressed:
                    result = "server_uncompressed.png";
                    break;
                case Icon.ServerWrench:
                    result = "server_wrench.png";
                    break;
                case Icon.Shading:
                    result = "shading.png";
                    break;
                case Icon.ShapesMany:
                    result = "shapes_many.png";
                    break;
                case Icon.ShapesManySelect:
                    result = "shapes_many_select.png";
                    break;
                case Icon.Shape3d:
                    result = "shape_3d.png";
                    break;
                case Icon.ShapeAlignBottom:
                    result = "shape_align_bottom.png";
                    break;
                case Icon.ShapeAlignCenter:
                    result = "shape_align_center.png";
                    break;
                case Icon.ShapeAlignLeft:
                    result = "shape_align_left.png";
                    break;
                case Icon.ShapeAlignMiddle:
                    result = "shape_align_middle.png";
                    break;
                case Icon.ShapeAlignRight:
                    result = "shape_align_right.png";
                    break;
                case Icon.ShapeAlignTop:
                    result = "shape_align_top.png";
                    break;
                case Icon.ShapeFlipHorizontal:
                    result = "shape_flip_horizontal.png";
                    break;
                case Icon.ShapeFlipVertical:
                    result = "shape_flip_vertical.png";
                    break;
                case Icon.ShapeGroup:
                    result = "shape_group.png";
                    break;
                case Icon.ShapeHandles:
                    result = "shape_handles.png";
                    break;
                case Icon.ShapeMoveBack:
                    result = "shape_move_back.png";
                    break;
                case Icon.ShapeMoveBackwards:
                    result = "shape_move_backwards.png";
                    break;
                case Icon.ShapeMoveForwards:
                    result = "shape_move_forwards.png";
                    break;
                case Icon.ShapeMoveFront:
                    result = "shape_move_front.png";
                    break;
                case Icon.ShapeRotateAnticlockwise:
                    result = "shape_rotate_anticlockwise.png";
                    break;
                case Icon.ShapeRotateClockwise:
                    result = "shape_rotate_clockwise.png";
                    break;
                case Icon.ShapeShadeA:
                    result = "shape_shade_a.png";
                    break;
                case Icon.ShapeShadeB:
                    result = "shape_shade_b.png";
                    break;
                case Icon.ShapeShadeC:
                    result = "shape_shade_c.png";
                    break;
                case Icon.ShapeShadow:
                    result = "shape_shadow.png";
                    break;
                case Icon.ShapeShadowToggle:
                    result = "shape_shadow_toggle.png";
                    break;
                case Icon.ShapeSquare:
                    result = "shape_square.png";
                    break;
                case Icon.ShapeSquareAdd:
                    result = "shape_square_add.png";
                    break;
                case Icon.ShapeSquareDelete:
                    result = "shape_square_delete.png";
                    break;
                case Icon.ShapeSquareEdit:
                    result = "shape_square_edit.png";
                    break;
                case Icon.ShapeSquareError:
                    result = "shape_square_error.png";
                    break;
                case Icon.ShapeSquareGo:
                    result = "shape_square_go.png";
                    break;
                case Icon.ShapeSquareKey:
                    result = "shape_square_key.png";
                    break;
                case Icon.ShapeSquareLink:
                    result = "shape_square_link.png";
                    break;
                case Icon.ShapeSquareSelect:
                    result = "shape_square_select.png";
                    break;
                case Icon.ShapeUngroup:
                    result = "shape_ungroup.png";
                    break;
                case Icon.Share:
                    result = "share.png";
                    break;
                case Icon.Shield:
                    result = "shield.png";
                    break;
                case Icon.ShieldAdd:
                    result = "shield_add.png";
                    break;
                case Icon.ShieldDelete:
                    result = "shield_delete.png";
                    break;
                case Icon.ShieldError:
                    result = "shield_error.png";
                    break;
                case Icon.ShieldGo:
                    result = "shield_go.png";
                    break;
                case Icon.ShieldRainbow:
                    result = "shield_rainbow.png";
                    break;
                case Icon.ShieldSilver:
                    result = "shield_silver.png";
                    break;
                case Icon.ShieldStart:
                    result = "shield_start.png";
                    break;
                case Icon.ShieldStop:
                    result = "shield_stop.png";
                    break;
                case Icon.Sitemap:
                    result = "sitemap.png";
                    break;
                case Icon.SitemapColor:
                    result = "sitemap_color.png";
                    break;
                case Icon.Smartphone:
                    result = "smartphone.png";
                    break;
                case Icon.SmartphoneAdd:
                    result = "smartphone_add.png";
                    break;
                case Icon.SmartphoneConnect:
                    result = "smartphone_connect.png";
                    break;
                case Icon.SmartphoneDelete:
                    result = "smartphone_delete.png";
                    break;
                case Icon.SmartphoneDisk:
                    result = "smartphone_disk.png";
                    break;
                case Icon.SmartphoneEdit:
                    result = "smartphone_edit.png";
                    break;
                case Icon.SmartphoneError:
                    result = "smartphone_error.png";
                    break;
                case Icon.SmartphoneGo:
                    result = "smartphone_go.png";
                    break;
                case Icon.SmartphoneKey:
                    result = "smartphone_key.png";
                    break;
                case Icon.SmartphoneWrench:
                    result = "smartphone_wrench.png";
                    break;
                case Icon.SortAscending:
                    result = "sort_ascending.png";
                    break;
                case Icon.SortDescending:
                    result = "sort_descending.png";
                    break;
                case Icon.Sound:
                    result = "sound.png";
                    break;
                case Icon.SoundAdd:
                    result = "sound_add.png";
                    break;
                case Icon.SoundDelete:
                    result = "sound_delete.png";
                    break;
                case Icon.SoundHigh:
                    result = "sound_high.png";
                    break;
                case Icon.SoundIn:
                    result = "sound_in.png";
                    break;
                case Icon.SoundLow:
                    result = "sound_low.png";
                    break;
                case Icon.SoundMute:
                    result = "sound_mute.png";
                    break;
                case Icon.SoundNone:
                    result = "sound_none.png";
                    break;
                case Icon.SoundOut:
                    result = "sound_out.png";
                    break;
                case Icon.Spellcheck:
                    result = "spellcheck.png";
                    break;
                case Icon.Sport8ball:
                    result = "sport_8ball.png";
                    break;
                case Icon.SportBasketball:
                    result = "sport_basketball.png";
                    break;
                case Icon.SportFootball:
                    result = "sport_football.png";
                    break;
                case Icon.SportGolf:
                    result = "sport_golf.png";
                    break;
                case Icon.SportGolfPractice:
                    result = "sport_golf_practice.png";
                    break;
                case Icon.SportRaquet:
                    result = "sport_raquet.png";
                    break;
                case Icon.SportShuttlecock:
                    result = "sport_shuttlecock.png";
                    break;
                case Icon.SportSoccer:
                    result = "sport_soccer.png";
                    break;
                case Icon.SportTennis:
                    result = "sport_tennis.png";
                    break;
                case Icon.Star:
                    result = "star.png";
                    break;
                case Icon.StarBronze:
                    result = "star_bronze.png";
                    break;
                case Icon.StarBronzeHalfGrey:
                    result = "star_bronze_half_grey.png";
                    break;
                case Icon.StarGold:
                    result = "star_gold.png";
                    break;
                case Icon.StarGoldHalfGrey:
                    result = "star_gold_half_grey.png";
                    break;
                case Icon.StarGoldHalfSilver:
                    result = "star_gold_half_silver.png";
                    break;
                case Icon.StarGrey:
                    result = "star_grey.png";
                    break;
                case Icon.StarHalfGrey:
                    result = "star_half_grey.png";
                    break;
                case Icon.StarSilver:
                    result = "star_silver.png";
                    break;
                case Icon.StatusAway:
                    result = "status_away.png";
                    break;
                case Icon.StatusBeRightBack:
                    result = "status_be_right_back.png";
                    break;
                case Icon.StatusBusy:
                    result = "status_busy.png";
                    break;
                case Icon.StatusInvisible:
                    result = "status_invisible.png";
                    break;
                case Icon.StatusOffline:
                    result = "status_offline.png";
                    break;
                case Icon.StatusOnline:
                    result = "status_online.png";
                    break;
                case Icon.Stop:
                    result = "stop.png";
                    break;
                case Icon.StopBlue:
                    result = "stop_blue.png";
                    break;
                case Icon.StopGreen:
                    result = "stop_green.png";
                    break;
                case Icon.StopRed:
                    result = "stop_red.png";
                    break;
                case Icon.Style:
                    result = "style.png";
                    break;
                case Icon.StyleAdd:
                    result = "style_add.png";
                    break;
                case Icon.StyleDelete:
                    result = "style_delete.png";
                    break;
                case Icon.StyleEdit:
                    result = "style_edit.png";
                    break;
                case Icon.StyleGo:
                    result = "style_go.png";
                    break;
                case Icon.Sum:
                    result = "sum.png";
                    break;
                case Icon.Tab:
                    result = "tab.png";
                    break;
                case Icon.Table:
                    result = "table.png";
                    break;
                case Icon.TableAdd:
                    result = "table_add.png";
                    break;
                case Icon.TableCell:
                    result = "table_cell.png";
                    break;
                case Icon.TableColumn:
                    result = "table_column.png";
                    break;
                case Icon.TableColumnAdd:
                    result = "table_column_add.png";
                    break;
                case Icon.TableColumnDelete:
                    result = "table_column_delete.png";
                    break;
                case Icon.TableConnect:
                    result = "table_connect.png";
                    break;
                case Icon.TableDelete:
                    result = "table_delete.png";
                    break;
                case Icon.TableEdit:
                    result = "table_edit.png";
                    break;
                case Icon.TableError:
                    result = "table_error.png";
                    break;
                case Icon.TableGear:
                    result = "table_gear.png";
                    break;
                case Icon.TableGo:
                    result = "table_go.png";
                    break;
                case Icon.TableKey:
                    result = "table_key.png";
                    break;
                case Icon.TableLightning:
                    result = "table_lightning.png";
                    break;
                case Icon.TableLink:
                    result = "table_link.png";
                    break;
                case Icon.TableMultiple:
                    result = "table_multiple.png";
                    break;
                case Icon.TableRefresh:
                    result = "table_refresh.png";
                    break;
                case Icon.TableRelationship:
                    result = "table_relationship.png";
                    break;
                case Icon.TableRow:
                    result = "table_row.png";
                    break;
                case Icon.TableRowDelete:
                    result = "table_row_delete.png";
                    break;
                case Icon.TableRowInsert:
                    result = "table_row_insert.png";
                    break;
                case Icon.TableSave:
                    result = "table_save.png";
                    break;
                case Icon.TableSort:
                    result = "table_sort.png";
                    break;
                case Icon.TabAdd:
                    result = "tab_add.png";
                    break;
                case Icon.TabBlue:
                    result = "tab_blue.png";
                    break;
                case Icon.TabDelete:
                    result = "tab_delete.png";
                    break;
                case Icon.TabEdit:
                    result = "tab_edit.png";
                    break;
                case Icon.TabGo:
                    result = "tab_go.png";
                    break;
                case Icon.TabGreen:
                    result = "tab_green.png";
                    break;
                case Icon.TabRed:
                    result = "tab_red.png";
                    break;
                case Icon.Tag:
                    result = "tag.png";
                    break;
                case Icon.TagsGrey:
                    result = "tags_grey.png";
                    break;
                case Icon.TagsRed:
                    result = "tags_red.png";
                    break;
                case Icon.TagBlue:
                    result = "tag_blue.png";
                    break;
                case Icon.TagBlueAdd:
                    result = "tag_blue_add.png";
                    break;
                case Icon.TagBlueDelete:
                    result = "tag_blue_delete.png";
                    break;
                case Icon.TagBlueEdit:
                    result = "tag_blue_edit.png";
                    break;
                case Icon.TagGreen:
                    result = "tag_green.png";
                    break;
                case Icon.TagOrange:
                    result = "tag_orange.png";
                    break;
                case Icon.TagPink:
                    result = "tag_pink.png";
                    break;
                case Icon.TagPurple:
                    result = "tag_purple.png";
                    break;
                case Icon.TagRed:
                    result = "tag_red.png";
                    break;
                case Icon.TagYellow:
                    result = "tag_yellow.png";
                    break;
                case Icon.Telephone:
                    result = "telephone.png";
                    break;
                case Icon.TelephoneAdd:
                    result = "telephone_add.png";
                    break;
                case Icon.TelephoneDelete:
                    result = "telephone_delete.png";
                    break;
                case Icon.TelephoneEdit:
                    result = "telephone_edit.png";
                    break;
                case Icon.TelephoneError:
                    result = "telephone_error.png";
                    break;
                case Icon.TelephoneGo:
                    result = "telephone_go.png";
                    break;
                case Icon.TelephoneKey:
                    result = "telephone_key.png";
                    break;
                case Icon.TelephoneLink:
                    result = "telephone_link.png";
                    break;
                case Icon.TelephoneRed:
                    result = "telephone_red.png";
                    break;
                case Icon.Television:
                    result = "television.png";
                    break;
                case Icon.TelevisionAdd:
                    result = "television_add.png";
                    break;
                case Icon.TelevisionDelete:
                    result = "television_delete.png";
                    break;
                case Icon.TelevisionIn:
                    result = "television_in.png";
                    break;
                case Icon.TelevisionOff:
                    result = "television_off.png";
                    break;
                case Icon.TelevisionOut:
                    result = "television_out.png";
                    break;
                case Icon.TelevisionStar:
                    result = "television_star.png";
                    break;
                case Icon.Textfield:
                    result = "textfield.png";
                    break;
                case Icon.TextfieldAdd:
                    result = "textfield_add.png";
                    break;
                case Icon.TextfieldDelete:
                    result = "textfield_delete.png";
                    break;
                case Icon.TextfieldKey:
                    result = "textfield_key.png";
                    break;
                case Icon.TextfieldRename:
                    result = "textfield_rename.png";
                    break;
                case Icon.TextAb:
                    result = "text_ab.png";
                    break;
                case Icon.TextAlignCenter:
                    result = "text_align_center.png";
                    break;
                case Icon.TextAlignJustify:
                    result = "text_align_justify.png";
                    break;
                case Icon.TextAlignLeft:
                    result = "text_align_left.png";
                    break;
                case Icon.TextAlignRight:
                    result = "text_align_right.png";
                    break;
                case Icon.TextAllcaps:
                    result = "text_allcaps.png";
                    break;
                case Icon.TextBold:
                    result = "text_bold.png";
                    break;
                case Icon.TextColumns:
                    result = "text_columns.png";
                    break;
                case Icon.TextComplete:
                    result = "text_complete.png";
                    break;
                case Icon.TextDirection:
                    result = "text_direction.png";
                    break;
                case Icon.TextDoubleUnderline:
                    result = "text_double_underline.png";
                    break;
                case Icon.TextDropcaps:
                    result = "text_dropcaps.png";
                    break;
                case Icon.TextFit:
                    result = "text_fit.png";
                    break;
                case Icon.TextFlip:
                    result = "text_flip.png";
                    break;
                case Icon.TextFontDefault:
                    result = "text_font_default.png";
                    break;
                case Icon.TextHeading1:
                    result = "text_heading_1.png";
                    break;
                case Icon.TextHeading2:
                    result = "text_heading_2.png";
                    break;
                case Icon.TextHeading3:
                    result = "text_heading_3.png";
                    break;
                case Icon.TextHeading4:
                    result = "text_heading_4.png";
                    break;
                case Icon.TextHeading5:
                    result = "text_heading_5.png";
                    break;
                case Icon.TextHeading6:
                    result = "text_heading_6.png";
                    break;
                case Icon.TextHorizontalrule:
                    result = "text_horizontalrule.png";
                    break;
                case Icon.TextIndent:
                    result = "text_indent.png";
                    break;
                case Icon.TextIndentRemove:
                    result = "text_indent_remove.png";
                    break;
                case Icon.TextInverse:
                    result = "text_inverse.png";
                    break;
                case Icon.TextItalic:
                    result = "text_italic.png";
                    break;
                case Icon.TextKerning:
                    result = "text_kerning.png";
                    break;
                case Icon.TextLeftToRight:
                    result = "text_left_to_right.png";
                    break;
                case Icon.TextLetterspacing:
                    result = "text_letterspacing.png";
                    break;
                case Icon.TextLetterOmega:
                    result = "text_letter_omega.png";
                    break;
                case Icon.TextLinespacing:
                    result = "text_linespacing.png";
                    break;
                case Icon.TextListBullets:
                    result = "text_list_bullets.png";
                    break;
                case Icon.TextListNumbers:
                    result = "text_list_numbers.png";
                    break;
                case Icon.TextLowercase:
                    result = "text_lowercase.png";
                    break;
                case Icon.TextLowercaseA:
                    result = "text_lowercase_a.png";
                    break;
                case Icon.TextMirror:
                    result = "text_mirror.png";
                    break;
                case Icon.TextPaddingBottom:
                    result = "text_padding_bottom.png";
                    break;
                case Icon.TextPaddingLeft:
                    result = "text_padding_left.png";
                    break;
                case Icon.TextPaddingRight:
                    result = "text_padding_right.png";
                    break;
                case Icon.TextPaddingTop:
                    result = "text_padding_top.png";
                    break;
                case Icon.TextReplace:
                    result = "text_replace.png";
                    break;
                case Icon.TextRightToLeft:
                    result = "text_right_to_left.png";
                    break;
                case Icon.TextRotate0:
                    result = "text_rotate_0.png";
                    break;
                case Icon.TextRotate180:
                    result = "text_rotate_180.png";
                    break;
                case Icon.TextRotate270:
                    result = "text_rotate_270.png";
                    break;
                case Icon.TextRotate90:
                    result = "text_rotate_90.png";
                    break;
                case Icon.TextRuler:
                    result = "text_ruler.png";
                    break;
                case Icon.TextShading:
                    result = "text_shading.png";
                    break;
                case Icon.TextSignature:
                    result = "text_signature.png";
                    break;
                case Icon.TextSmallcaps:
                    result = "text_smallcaps.png";
                    break;
                case Icon.TextSpelling:
                    result = "text_spelling.png";
                    break;
                case Icon.TextStrikethrough:
                    result = "text_strikethrough.png";
                    break;
                case Icon.TextSubscript:
                    result = "text_subscript.png";
                    break;
                case Icon.TextSuperscript:
                    result = "text_superscript.png";
                    break;
                case Icon.TextTab:
                    result = "text_tab.png";
                    break;
                case Icon.TextUnderline:
                    result = "text_underline.png";
                    break;
                case Icon.TextUppercase:
                    result = "text_uppercase.png";
                    break;
                case Icon.Theme:
                    result = "theme.png";
                    break;
                case Icon.ThumbDown:
                    result = "thumb_down.png";
                    break;
                case Icon.ThumbUp:
                    result = "thumb_up.png";
                    break;
                case Icon.Tick:
                    result = "tick.png";
                    break;
                case Icon.Time:
                    result = "time.png";
                    break;
                case Icon.TimelineMarker:
                    result = "timeline_marker.png";
                    break;
                case Icon.TimeAdd:
                    result = "time_add.png";
                    break;
                case Icon.TimeDelete:
                    result = "time_delete.png";
                    break;
                case Icon.TimeGo:
                    result = "time_go.png";
                    break;
                case Icon.TimeGreen:
                    result = "time_green.png";
                    break;
                case Icon.TimeRed:
                    result = "time_red.png";
                    break;
                case Icon.Transmit:
                    result = "transmit.png";
                    break;
                case Icon.TransmitAdd:
                    result = "transmit_add.png";
                    break;
                case Icon.TransmitBlue:
                    result = "transmit_blue.png";
                    break;
                case Icon.TransmitDelete:
                    result = "transmit_delete.png";
                    break;
                case Icon.TransmitEdit:
                    result = "transmit_edit.png";
                    break;
                case Icon.TransmitError:
                    result = "transmit_error.png";
                    break;
                case Icon.TransmitGo:
                    result = "transmit_go.png";
                    break;
                case Icon.TransmitRed:
                    result = "transmit_red.png";
                    break;
                case Icon.Tux:
                    result = "tux.png";
                    break;
                case Icon.User:
                    result = "user.png";
                    break;
                case Icon.UserAdd:
                    result = "user_add.png";
                    break;
                case Icon.UserAlert:
                    result = "user_alert.png";
                    break;
                case Icon.UserB:
                    result = "user_b.png";
                    break;
                case Icon.UserBrown:
                    result = "user_brown.png";
                    break;
                case Icon.UserComment:
                    result = "user_comment.png";
                    break;
                case Icon.UserCross:
                    result = "user_cross.png";
                    break;
                case Icon.UserDelete:
                    result = "user_delete.png";
                    break;
                case Icon.UserEarth:
                    result = "user_earth.png";
                    break;
                case Icon.UserEdit:
                    result = "user_edit.png";
                    break;
                case Icon.UserFemale:
                    result = "user_female.png";
                    break;
                case Icon.UserGo:
                    result = "user_go.png";
                    break;
                case Icon.UserGray:
                    result = "user_gray.png";
                    break;
                case Icon.UserGrayCool:
                    result = "user_gray_cool.png";
                    break;
                case Icon.UserGreen:
                    result = "user_green.png";
                    break;
                case Icon.UserHome:
                    result = "user_home.png";
                    break;
                case Icon.UserKey:
                    result = "user_key.png";
                    break;
                case Icon.UserMagnify:
                    result = "user_magnify.png";
                    break;
                case Icon.UserMature:
                    result = "user_mature.png";
                    break;
                case Icon.UserOrange:
                    result = "user_orange.png";
                    break;
                case Icon.UserRed:
                    result = "user_red.png";
                    break;
                case Icon.UserStar:
                    result = "user_star.png";
                    break;
                case Icon.UserSuit:
                    result = "user_suit.png";
                    break;
                case Icon.UserSuitBlack:
                    result = "user_suit_black.png";
                    break;
                case Icon.UserTick:
                    result = "user_tick.png";
                    break;
                case Icon.Vcard:
                    result = "vcard.png";
                    break;
                case Icon.VcardAdd:
                    result = "vcard_add.png";
                    break;
                case Icon.VcardDelete:
                    result = "vcard_delete.png";
                    break;
                case Icon.VcardEdit:
                    result = "vcard_edit.png";
                    break;
                case Icon.VcardKey:
                    result = "vcard_key.png";
                    break;
                case Icon.Vector:
                    result = "vector.png";
                    break;
                case Icon.VectorAdd:
                    result = "vector_add.png";
                    break;
                case Icon.VectorDelete:
                    result = "vector_delete.png";
                    break;
                case Icon.VectorKey:
                    result = "vector_key.png";
                    break;
                case Icon.Wand:
                    result = "wand.png";
                    break;
                case Icon.WeatherCloud:
                    result = "weather_cloud.png";
                    break;
                case Icon.WeatherClouds:
                    result = "weather_clouds.png";
                    break;
                case Icon.WeatherCloudy:
                    result = "weather_cloudy.png";
                    break;
                case Icon.WeatherCloudyRain:
                    result = "weather_cloudy_rain.png";
                    break;
                case Icon.WeatherLightning:
                    result = "weather_lightning.png";
                    break;
                case Icon.WeatherRain:
                    result = "weather_rain.png";
                    break;
                case Icon.WeatherSnow:
                    result = "weather_snow.png";
                    break;
                case Icon.WeatherSun:
                    result = "weather_sun.png";
                    break;
                case Icon.Webcam:
                    result = "webcam.png";
                    break;
                case Icon.WebcamAdd:
                    result = "webcam_add.png";
                    break;
                case Icon.WebcamConnect:
                    result = "webcam_connect.png";
                    break;
                case Icon.WebcamDelete:
                    result = "webcam_delete.png";
                    break;
                case Icon.WebcamError:
                    result = "webcam_error.png";
                    break;
                case Icon.WebcamStart:
                    result = "webcam_start.png";
                    break;
                case Icon.WebcamStop:
                    result = "webcam_stop.png";
                    break;
                case Icon.World:
                    result = "world.png";
                    break;
                case Icon.WorldAdd:
                    result = "world_add.png";
                    break;
                case Icon.WorldConnect:
                    result = "world_connect.png";
                    break;
                case Icon.WorldDawn:
                    result = "world_dawn.png";
                    break;
                case Icon.WorldDelete:
                    result = "world_delete.png";
                    break;
                case Icon.WorldEdit:
                    result = "world_edit.png";
                    break;
                case Icon.WorldGo:
                    result = "world_go.png";
                    break;
                case Icon.WorldKey:
                    result = "world_key.png";
                    break;
                case Icon.WorldLink:
                    result = "world_link.png";
                    break;
                case Icon.WorldNight:
                    result = "world_night.png";
                    break;
                case Icon.WorldOrbit:
                    result = "world_orbit.png";
                    break;
                case Icon.Wrench:
                    result = "wrench.png";
                    break;
                case Icon.WrenchOrange:
                    result = "wrench_orange.png";
                    break;
                case Icon.Xhtml:
                    result = "xhtml.png";
                    break;
                case Icon.XhtmlAdd:
                    result = "xhtml_add.png";
                    break;
                case Icon.XhtmlDelete:
                    result = "xhtml_delete.png";
                    break;
                case Icon.XhtmlError:
                    result = "xhtml_error.png";
                    break;
                case Icon.XhtmlGo:
                    result = "xhtml_go.png";
                    break;
                case Icon.XhtmlValid:
                    result = "xhtml_valid.png";
                    break;
                case Icon.Zoom:
                    result = "zoom.png";
                    break;
                case Icon.ZoomIn:
                    result = "zoom_in.png";
                    break;
                case Icon.ZoomOut:
                    result = "zoom_out.png";
                    break;
                case Icon.SystemClose:
                    result = "system_close.gif";
                    break;
                case Icon.SystemNew:
                    result = "system_new.gif";
                    break;
                case Icon.SystemSave:
                    result = "system_save.gif";
                    break;
                case Icon.SystemSaveClose:
                    result = "system_saveclose.gif";
                    break;
                case Icon.SystemSaveNew:
                    result = "system_savenew.gif";
                    break;
                case Icon.SystemSearch:
                    result = "system_search.gif";
                    break;
            }

            return result;
        }
    }
}