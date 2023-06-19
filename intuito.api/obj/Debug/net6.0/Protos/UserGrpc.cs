// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/user.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981
#region Designer generated code

using grpc = global::Grpc.Core;

namespace intuito.api.user.Protos {
  public static partial class User
  {
    static readonly string __ServiceName = "user.User";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::intuito.api.user.Protos.UserRequest> __Marshaller_user_UserRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::intuito.api.user.Protos.UserRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::intuito.api.user.Protos.UserResponse> __Marshaller_user_UserResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::intuito.api.user.Protos.UserResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::intuito.api.user.Protos.UserIdRequest> __Marshaller_user_UserIdRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::intuito.api.user.Protos.UserIdRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::intuito.api.user.Protos.UserIdResponse> __Marshaller_user_UserIdResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::intuito.api.user.Protos.UserIdResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::intuito.api.user.Protos.UserRequest, global::intuito.api.user.Protos.UserResponse> __Method_AddUser = new grpc::Method<global::intuito.api.user.Protos.UserRequest, global::intuito.api.user.Protos.UserResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "AddUser",
        __Marshaller_user_UserRequest,
        __Marshaller_user_UserResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::intuito.api.user.Protos.UserIdRequest, global::intuito.api.user.Protos.UserIdResponse> __Method_GetUser = new grpc::Method<global::intuito.api.user.Protos.UserIdRequest, global::intuito.api.user.Protos.UserIdResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetUser",
        __Marshaller_user_UserIdRequest,
        __Marshaller_user_UserIdResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::intuito.api.user.Protos.UserReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of User</summary>
    [grpc::BindServiceMethod(typeof(User), "BindService")]
    public abstract partial class UserBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::intuito.api.user.Protos.UserResponse> AddUser(global::intuito.api.user.Protos.UserRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::intuito.api.user.Protos.UserIdResponse> GetUser(global::intuito.api.user.Protos.UserIdRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(UserBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_AddUser, serviceImpl.AddUser)
          .AddMethod(__Method_GetUser, serviceImpl.GetUser).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, UserBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_AddUser, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::intuito.api.user.Protos.UserRequest, global::intuito.api.user.Protos.UserResponse>(serviceImpl.AddUser));
      serviceBinder.AddMethod(__Method_GetUser, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::intuito.api.user.Protos.UserIdRequest, global::intuito.api.user.Protos.UserIdResponse>(serviceImpl.GetUser));
    }

  }
}
#endregion