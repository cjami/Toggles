#pragma warning disable 612,618
#pragma warning disable 0114
#pragma warning disable 0108

using System;
using System.Collections.Generic;
using GameSparks.Core;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;

//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!
//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!
//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!

namespace GameSparks.Api.Requests{
		public class LogEventRequest_ADD_NODE : GSTypedRequest<LogEventRequest_ADD_NODE, LogEventResponse>
	{
	
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogEventResponse (response);
		}
		
		public LogEventRequest_ADD_NODE() : base("LogEventRequest"){
			request.AddString("eventKey", "ADD_NODE");
		}
		
		public LogEventRequest_ADD_NODE Set_LON( string value )
		{
			request.AddString("LON", value);
			return this;
		}
		
		public LogEventRequest_ADD_NODE Set_LAT( string value )
		{
			request.AddString("LAT", value);
			return this;
		}
		
		public LogEventRequest_ADD_NODE Set_TYPE( string value )
		{
			request.AddString("TYPE", value);
			return this;
		}
		
		public LogEventRequest_ADD_NODE Set_FILL( string value )
		{
			request.AddString("FILL", value);
			return this;
		}
	}
	
	public class LogChallengeEventRequest_ADD_NODE : GSTypedRequest<LogChallengeEventRequest_ADD_NODE, LogChallengeEventResponse>
	{
		public LogChallengeEventRequest_ADD_NODE() : base("LogChallengeEventRequest"){
			request.AddString("eventKey", "ADD_NODE");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogChallengeEventResponse (response);
		}
		
		/// <summary>
		/// The challenge ID instance to target
		/// </summary>
		public LogChallengeEventRequest_ADD_NODE SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		public LogChallengeEventRequest_ADD_NODE Set_LON( string value )
		{
			request.AddString("LON", value);
			return this;
		}
		public LogChallengeEventRequest_ADD_NODE Set_LAT( string value )
		{
			request.AddString("LAT", value);
			return this;
		}
		public LogChallengeEventRequest_ADD_NODE Set_TYPE( string value )
		{
			request.AddString("TYPE", value);
			return this;
		}
		public LogChallengeEventRequest_ADD_NODE Set_FILL( string value )
		{
			request.AddString("FILL", value);
			return this;
		}
	}
	
	public class LogEventRequest_GET_NEARBY_NODES : GSTypedRequest<LogEventRequest_GET_NEARBY_NODES, LogEventResponse>
	{
	
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogEventResponse (response);
		}
		
		public LogEventRequest_GET_NEARBY_NODES() : base("LogEventRequest"){
			request.AddString("eventKey", "GET_NEARBY_NODES");
		}
		
		public LogEventRequest_GET_NEARBY_NODES Set_LON( string value )
		{
			request.AddString("LON", value);
			return this;
		}
		
		public LogEventRequest_GET_NEARBY_NODES Set_LAT( string value )
		{
			request.AddString("LAT", value);
			return this;
		}
	}
	
	public class LogChallengeEventRequest_GET_NEARBY_NODES : GSTypedRequest<LogChallengeEventRequest_GET_NEARBY_NODES, LogChallengeEventResponse>
	{
		public LogChallengeEventRequest_GET_NEARBY_NODES() : base("LogChallengeEventRequest"){
			request.AddString("eventKey", "GET_NEARBY_NODES");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogChallengeEventResponse (response);
		}
		
		/// <summary>
		/// The challenge ID instance to target
		/// </summary>
		public LogChallengeEventRequest_GET_NEARBY_NODES SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		public LogChallengeEventRequest_GET_NEARBY_NODES Set_LON( string value )
		{
			request.AddString("LON", value);
			return this;
		}
		public LogChallengeEventRequest_GET_NEARBY_NODES Set_LAT( string value )
		{
			request.AddString("LAT", value);
			return this;
		}
	}
	
}
	

namespace GameSparks.Api.Messages {


}
