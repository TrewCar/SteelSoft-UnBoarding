# УСТАНОВКА
## ВОСТАНОВЛЕНИЕ БД

Востановить бд из файлв BackUp_DB.sql в PostgreSQL 15

## КОНФИГИ

Настоить конфиги по пути /SteelSoft-UnBoardind/config.cs

```
public static class Config
  {
      public static string HOST { get; private set; } = "localhost";
      public static string PORT { get; private set; } = "5432";
      public static string USER { get; private set; } = "postgres";
      public static string PASS { get; private set; } = "2648";
      public static string DATABASE { get; private set; } = "unboarding";
  }
```
