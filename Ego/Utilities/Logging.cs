global using static Utilities.Logging;

using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;
using ZLogger;

namespace Utilities;

public static class Logging
{
    //This is set from EgoRoot
    public static ILogger Log = null!;
    
    
    //Nicos: These are all copy-pasted from the same file as the ZLog methods. I wanted to alias, so you write Log.Info instead of Log.ZLogInformation
    
    public static void Trace(
      this ILogger logger,
      [InterpolatedStringHandlerArgument("logger")] ref ZLoggerTraceInterpolatedStringHandler message,
      object? context = null,
      [CallerMemberName] string? memberName = null,
      [CallerFilePath] string? filePath = null,
      [CallerLineNumber] int lineNumber = 0)
    {
      logger.ZLog(LogLevel.Trace, new EventId(), (Exception) null!, ref message.InnerHandler, context, memberName, filePath, lineNumber);
    }

    public static void Trace(
      this ILogger logger,
      EventId eventId,
      [InterpolatedStringHandlerArgument("logger")] ref ZLoggerTraceInterpolatedStringHandler message,
      object? context = null,
      [CallerMemberName] string? memberName = null,
      [CallerFilePath] string? filePath = null,
      [CallerLineNumber] int lineNumber = 0)
    {
      logger.ZLog(LogLevel.Trace, eventId, (Exception) null!, ref message.InnerHandler, context, memberName, filePath, lineNumber);
    }

    public static void Trace(
      this ILogger logger,
      Exception? exception,
      [InterpolatedStringHandlerArgument("logger")] ref ZLoggerTraceInterpolatedStringHandler message,
      object? context = null,
      [CallerMemberName] string? memberName = null,
      [CallerFilePath] string? filePath = null,
      [CallerLineNumber] int lineNumber = 0)
    {
      logger.ZLog(LogLevel.Trace, new EventId(), exception, ref message.InnerHandler, context, memberName, filePath, lineNumber);
    }

    public static void Trace(
      this ILogger logger,
      EventId eventId,
      Exception? exception,
      [InterpolatedStringHandlerArgument("logger")] ref ZLoggerTraceInterpolatedStringHandler message,
      object? context = null,
      [CallerMemberName] string? memberName = null,
      [CallerFilePath] string? filePath = null,
      [CallerLineNumber] int lineNumber = 0)
    {
      logger.ZLog(LogLevel.Trace, eventId, exception, ref message.InnerHandler, context, memberName, filePath, lineNumber);
    }

    public static void Debug(
      this ILogger logger,
      [InterpolatedStringHandlerArgument("logger")] ref ZLoggerDebugInterpolatedStringHandler message,
      object? context = null,
      [CallerMemberName] string? memberName = null,
      [CallerFilePath] string? filePath = null,
      [CallerLineNumber] int lineNumber = 0)
    {
      logger.ZLog(LogLevel.Debug, new EventId(), (Exception) null!, ref message.InnerHandler, context, memberName, filePath, lineNumber);
    }

    public static void Debug(
      this ILogger logger,
      EventId eventId,
      [InterpolatedStringHandlerArgument("logger")] ref ZLoggerDebugInterpolatedStringHandler message,
      object? context = null,
      [CallerMemberName] string? memberName = null,
      [CallerFilePath] string? filePath = null,
      [CallerLineNumber] int lineNumber = 0)
    {
      logger.ZLog(LogLevel.Debug, eventId, (Exception) null!, ref message.InnerHandler, context, memberName, filePath, lineNumber);
    }

    public static void Debug(
      this ILogger logger,
      Exception? exception,
      [InterpolatedStringHandlerArgument("logger")] ref ZLoggerDebugInterpolatedStringHandler message,
      object? context = null,
      [CallerMemberName] string? memberName = null,
      [CallerFilePath] string? filePath = null,
      [CallerLineNumber] int lineNumber = 0)
    {
      logger.ZLog(LogLevel.Debug, new EventId(), exception, ref message.InnerHandler, context, memberName, filePath, lineNumber);
    }

    public static void Debug(
      this ILogger logger,
      EventId eventId,
      Exception? exception,
      [InterpolatedStringHandlerArgument("logger")] ref ZLoggerDebugInterpolatedStringHandler message,
      object? context = null,
      [CallerMemberName] string? memberName = null,
      [CallerFilePath] string? filePath = null,
      [CallerLineNumber] int lineNumber = 0)
    {
      logger.ZLog(LogLevel.Debug, eventId, exception, ref message.InnerHandler, context, memberName, filePath, lineNumber);
    }

    public static void Info(
      this ILogger logger,
      [InterpolatedStringHandlerArgument("logger")] ref ZLoggerInformationInterpolatedStringHandler message,
      object? context = null,
      [CallerMemberName] string? memberName = null,
      [CallerFilePath] string? filePath = null,
      [CallerLineNumber] int lineNumber = 0)
    {
      logger.ZLog(LogLevel.Information, new EventId(), (Exception) null!, ref message.InnerHandler, context, memberName, filePath, lineNumber);
    }

    public static void Info(
      this ILogger logger,
      EventId eventId,
      [InterpolatedStringHandlerArgument("logger")] ref ZLoggerInformationInterpolatedStringHandler message,
      object? context = null,
      [CallerMemberName] string? memberName = null,
      [CallerFilePath] string? filePath = null,
      [CallerLineNumber] int lineNumber = 0)
    {
      logger.ZLog(LogLevel.Information, eventId, (Exception) null!, ref message.InnerHandler, context, memberName, filePath, lineNumber);
    }

    public static void Info(
      this ILogger logger,
      Exception? exception,
      [InterpolatedStringHandlerArgument("logger")] ref ZLoggerInformationInterpolatedStringHandler message,
      object? context = null,
      [CallerMemberName] string? memberName = null,
      [CallerFilePath] string? filePath = null,
      [CallerLineNumber] int lineNumber = 0)
    {
      logger.ZLog(LogLevel.Information, new EventId(), exception, ref message.InnerHandler, context, memberName, filePath, lineNumber);
    }

    public static void Info(
      this ILogger logger,
      EventId eventId,
      Exception? exception,
      [InterpolatedStringHandlerArgument("logger")] ref ZLoggerInformationInterpolatedStringHandler message,
      object? context = null,
      [CallerMemberName] string? memberName = null,
      [CallerFilePath] string? filePath = null,
      [CallerLineNumber] int lineNumber = 0)
    {
      logger.ZLog(LogLevel.Information, eventId, exception, ref message.InnerHandler, context, memberName, filePath, lineNumber);
    }

    public static void Warning(
      this ILogger logger,
      [InterpolatedStringHandlerArgument("logger")] ref ZLoggerWarningInterpolatedStringHandler message,
      object? context = null,
      [CallerMemberName] string? memberName = null,
      [CallerFilePath] string? filePath = null,
      [CallerLineNumber] int lineNumber = 0)
    {
      logger.ZLog(LogLevel.Warning, new EventId(), (Exception) null!, ref message.InnerHandler, context, memberName, filePath, lineNumber);
    }

    public static void Warning(
      this ILogger logger,
      EventId eventId,
      [InterpolatedStringHandlerArgument("logger")] ref ZLoggerWarningInterpolatedStringHandler message,
      object? context = null,
      [CallerMemberName] string? memberName = null,
      [CallerFilePath] string? filePath = null,
      [CallerLineNumber] int lineNumber = 0)
    {
      logger.ZLog(LogLevel.Warning, eventId, (Exception) null!, ref message.InnerHandler, context, memberName, filePath, lineNumber);
    }

    public static void Warning(
      this ILogger logger,
      Exception? exception,
      [InterpolatedStringHandlerArgument("logger")] ref ZLoggerWarningInterpolatedStringHandler message,
      object? context = null,
      [CallerMemberName] string? memberName = null,
      [CallerFilePath] string? filePath = null,
      [CallerLineNumber] int lineNumber = 0)
    {
      logger.ZLog(LogLevel.Warning, new EventId(), exception, ref message.InnerHandler, context, memberName, filePath, lineNumber);
    }

    public static void Warning(
      this ILogger logger,
      EventId eventId,
      Exception? exception,
      [InterpolatedStringHandlerArgument("logger")] ref ZLoggerWarningInterpolatedStringHandler message,
      object? context = null,
      [CallerMemberName] string? memberName = null,
      [CallerFilePath] string? filePath = null,
      [CallerLineNumber] int lineNumber = 0)
    {
      logger.ZLog(LogLevel.Warning, eventId, exception, ref message.InnerHandler, context, memberName, filePath, lineNumber);
    }

    public static void Error(
      this ILogger logger,
      [InterpolatedStringHandlerArgument("logger")] ref ZLoggerErrorInterpolatedStringHandler message,
      object? context = null,
      [CallerMemberName] string? memberName = null,
      [CallerFilePath] string? filePath = null,
      [CallerLineNumber] int lineNumber = 0)
    {
      logger.ZLog(LogLevel.Error, new EventId(), (Exception) null!, ref message.InnerHandler, context, memberName, filePath, lineNumber);
    }

    public static void Error(
      this ILogger logger,
      EventId eventId,
      [InterpolatedStringHandlerArgument("logger")] ref ZLoggerErrorInterpolatedStringHandler message,
      object? context = null,
      [CallerMemberName] string? memberName = null,
      [CallerFilePath] string? filePath = null,
      [CallerLineNumber] int lineNumber = 0)
    {
      logger.ZLog(LogLevel.Error, eventId, (Exception) null!, ref message.InnerHandler, context, memberName, filePath, lineNumber);
    }

    public static void Error(
      this ILogger logger,
      Exception? exception,
      [InterpolatedStringHandlerArgument("logger")] ref ZLoggerErrorInterpolatedStringHandler message,
      object? context = null,
      [CallerMemberName] string? memberName = null,
      [CallerFilePath] string? filePath = null,
      [CallerLineNumber] int lineNumber = 0)
    {
      logger.ZLog(LogLevel.Error, new EventId(), exception, ref message.InnerHandler, context, memberName, filePath, lineNumber);
    }

    public static void Error(
      this ILogger logger,
      EventId eventId,
      Exception? exception,
      [InterpolatedStringHandlerArgument("logger")] ref ZLoggerErrorInterpolatedStringHandler message,
      object? context = null,
      [CallerMemberName] string? memberName = null,
      [CallerFilePath] string? filePath = null,
      [CallerLineNumber] int lineNumber = 0)
    {
      logger.ZLog(LogLevel.Error, eventId, exception, ref message.InnerHandler, context, memberName, filePath, lineNumber);
    }

    public static void Critical(
      this ILogger logger,
      [InterpolatedStringHandlerArgument("logger")] ref ZLoggerCriticalInterpolatedStringHandler message,
      object? context = null,
      [CallerMemberName] string? memberName = null,
      [CallerFilePath] string? filePath = null,
      [CallerLineNumber] int lineNumber = 0)
    {
      logger.ZLog(LogLevel.Critical, new EventId(), (Exception) null!, ref message.InnerHandler, context, memberName, filePath, lineNumber);
    }

    public static void Critical(
      this ILogger logger,
      EventId eventId,
      [InterpolatedStringHandlerArgument("logger")] ref ZLoggerCriticalInterpolatedStringHandler message,
      object? context = null,
      [CallerMemberName] string? memberName = null,
      [CallerFilePath] string? filePath = null,
      [CallerLineNumber] int lineNumber = 0)
    {
      logger.ZLog(LogLevel.Critical, eventId, (Exception) null!, ref message.InnerHandler, context, memberName, filePath, lineNumber);
    }

    public static void Critical(
      this ILogger logger,
      Exception? exception,
      [InterpolatedStringHandlerArgument("logger")] ref ZLoggerCriticalInterpolatedStringHandler message,
      object? context = null,
      [CallerMemberName] string? memberName = null,
      [CallerFilePath] string? filePath = null,
      [CallerLineNumber] int lineNumber = 0)
    {
      logger.ZLog(LogLevel.Critical, new EventId(), exception, ref message.InnerHandler, context, memberName, filePath, lineNumber);
    }

    public static void Critical(
      this ILogger logger,
      EventId eventId,
      Exception? exception,
      [InterpolatedStringHandlerArgument("logger")] ref ZLoggerCriticalInterpolatedStringHandler message,
      object? context = null,
      [CallerMemberName] string? memberName = null,
      [CallerFilePath] string? filePath = null,
      [CallerLineNumber] int lineNumber = 0)
    {
      logger.ZLog(LogLevel.Critical, eventId, exception, ref message.InnerHandler, context, memberName, filePath, lineNumber);
    }
}