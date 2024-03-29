/**
 * @fileoverview gRPC-Web generated client stub for order
 * @enhanceable
 * @public
 */

// Code generated by protoc-gen-grpc-web. DO NOT EDIT.
// versions:
// 	protoc-gen-grpc-web v1.4.2
// 	protoc              v4.24.1
// source: order.proto


/* eslint-disable */
// @ts-nocheck



const grpc = {};
grpc.web = require('grpc-web');


var google_protobuf_timestamp_pb = require('google-protobuf/google/protobuf/timestamp_pb.js')
const proto = {};
proto.order = require('./order_pb.js');

/**
 * @param {string} hostname
 * @param {?Object} credentials
 * @param {?grpc.web.ClientOptions} options
 * @constructor
 * @struct
 * @final
 */
proto.order.OrderProviderClient =
    function(hostname, credentials, options) {
  if (!options) options = {};
  options.format = 'text';

  /**
   * @private @const {!grpc.web.GrpcWebClientBase} The client
   */
  this.client_ = new grpc.web.GrpcWebClientBase(options);

  /**
   * @private @const {string} The hostname
   */
  this.hostname_ = hostname.replace(/\/+$/, '');

};


/**
 * @param {string} hostname
 * @param {?Object} credentials
 * @param {?grpc.web.ClientOptions} options
 * @constructor
 * @struct
 * @final
 */
proto.order.OrderProviderPromiseClient =
    function(hostname, credentials, options) {
  if (!options) options = {};
  options.format = 'text';

  /**
   * @private @const {!grpc.web.GrpcWebClientBase} The client
   */
  this.client_ = new grpc.web.GrpcWebClientBase(options);

  /**
   * @private @const {string} The hostname
   */
  this.hostname_ = hostname.replace(/\/+$/, '');

};


/**
 * @const
 * @type {!grpc.web.MethodDescriptor<
 *   !proto.order.OrderRequest,
 *   !proto.order.OrderResponse>}
 */
const methodDescriptor_OrderProvider_GetOrder = new grpc.web.MethodDescriptor(
  '/order.OrderProvider/GetOrder',
  grpc.web.MethodType.UNARY,
  proto.order.OrderRequest,
  proto.order.OrderResponse,
  /**
   * @param {!proto.order.OrderRequest} request
   * @return {!Uint8Array}
   */
  function(request) {
    return request.serializeBinary();
  },
  proto.order.OrderResponse.deserializeBinary
);


/**
 * @param {!proto.order.OrderRequest} request The
 *     request proto
 * @param {?Object<string, string>} metadata User defined
 *     call metadata
 * @param {function(?grpc.web.RpcError, ?proto.order.OrderResponse)}
 *     callback The callback function(error, response)
 * @return {!grpc.web.ClientReadableStream<!proto.order.OrderResponse>|undefined}
 *     The XHR Node Readable Stream
 */
proto.order.OrderProviderClient.prototype.getOrder =
    function(request, metadata, callback) {
  return this.client_.rpcCall(this.hostname_ +
      '/order.OrderProvider/GetOrder',
      request,
      metadata || {},
      methodDescriptor_OrderProvider_GetOrder,
      callback);
};


/**
 * @param {!proto.order.OrderRequest} request The
 *     request proto
 * @param {?Object<string, string>=} metadata User defined
 *     call metadata
 * @return {!Promise<!proto.order.OrderResponse>}
 *     Promise that resolves to the response
 */
proto.order.OrderProviderPromiseClient.prototype.getOrder =
    function(request, metadata) {
  return this.client_.unaryCall(this.hostname_ +
      '/order.OrderProvider/GetOrder',
      request,
      metadata || {},
      methodDescriptor_OrderProvider_GetOrder);
};


/**
 * @const
 * @type {!grpc.web.MethodDescriptor<
 *   !proto.order.OrderCriteria,
 *   !proto.order.Order>}
 */
const methodDescriptor_OrderProvider_SubscribeOrder = new grpc.web.MethodDescriptor(
  '/order.OrderProvider/SubscribeOrder',
  grpc.web.MethodType.SERVER_STREAMING,
  proto.order.OrderCriteria,
  proto.order.Order,
  /**
   * @param {!proto.order.OrderCriteria} request
   * @return {!Uint8Array}
   */
  function(request) {
    return request.serializeBinary();
  },
  proto.order.Order.deserializeBinary
);


/**
 * @param {!proto.order.OrderCriteria} request The request proto
 * @param {?Object<string, string>=} metadata User defined
 *     call metadata
 * @return {!grpc.web.ClientReadableStream<!proto.order.Order>}
 *     The XHR Node Readable Stream
 */
proto.order.OrderProviderClient.prototype.subscribeOrder =
    function(request, metadata) {
  return this.client_.serverStreaming(this.hostname_ +
      '/order.OrderProvider/SubscribeOrder',
      request,
      metadata || {},
      methodDescriptor_OrderProvider_SubscribeOrder);
};


/**
 * @param {!proto.order.OrderCriteria} request The request proto
 * @param {?Object<string, string>=} metadata User defined
 *     call metadata
 * @return {!grpc.web.ClientReadableStream<!proto.order.Order>}
 *     The XHR Node Readable Stream
 */
proto.order.OrderProviderPromiseClient.prototype.subscribeOrder =
    function(request, metadata) {
  return this.client_.serverStreaming(this.hostname_ +
      '/order.OrderProvider/SubscribeOrder',
      request,
      metadata || {},
      methodDescriptor_OrderProvider_SubscribeOrder);
};


/**
 * @const
 * @type {!grpc.web.MethodDescriptor<
 *   !proto.order.FillCriteria,
 *   !proto.order.Fill>}
 */
const methodDescriptor_OrderProvider_SubscribeFill = new grpc.web.MethodDescriptor(
  '/order.OrderProvider/SubscribeFill',
  grpc.web.MethodType.SERVER_STREAMING,
  proto.order.FillCriteria,
  proto.order.Fill,
  /**
   * @param {!proto.order.FillCriteria} request
   * @return {!Uint8Array}
   */
  function(request) {
    return request.serializeBinary();
  },
  proto.order.Fill.deserializeBinary
);


/**
 * @param {!proto.order.FillCriteria} request The request proto
 * @param {?Object<string, string>=} metadata User defined
 *     call metadata
 * @return {!grpc.web.ClientReadableStream<!proto.order.Fill>}
 *     The XHR Node Readable Stream
 */
proto.order.OrderProviderClient.prototype.subscribeFill =
    function(request, metadata) {
  return this.client_.serverStreaming(this.hostname_ +
      '/order.OrderProvider/SubscribeFill',
      request,
      metadata || {},
      methodDescriptor_OrderProvider_SubscribeFill);
};


/**
 * @param {!proto.order.FillCriteria} request The request proto
 * @param {?Object<string, string>=} metadata User defined
 *     call metadata
 * @return {!grpc.web.ClientReadableStream<!proto.order.Fill>}
 *     The XHR Node Readable Stream
 */
proto.order.OrderProviderPromiseClient.prototype.subscribeFill =
    function(request, metadata) {
  return this.client_.serverStreaming(this.hostname_ +
      '/order.OrderProvider/SubscribeFill',
      request,
      metadata || {},
      methodDescriptor_OrderProvider_SubscribeFill);
};


/**
 * @param {string} hostname
 * @param {?Object} credentials
 * @param {?grpc.web.ClientOptions} options
 * @constructor
 * @struct
 * @final
 */
proto.order.OrderTransactionProviderClient =
    function(hostname, credentials, options) {
  if (!options) options = {};
  options.format = 'text';

  /**
   * @private @const {!grpc.web.GrpcWebClientBase} The client
   */
  this.client_ = new grpc.web.GrpcWebClientBase(options);

  /**
   * @private @const {string} The hostname
   */
  this.hostname_ = hostname.replace(/\/+$/, '');

};


/**
 * @param {string} hostname
 * @param {?Object} credentials
 * @param {?grpc.web.ClientOptions} options
 * @constructor
 * @struct
 * @final
 */
proto.order.OrderTransactionProviderPromiseClient =
    function(hostname, credentials, options) {
  if (!options) options = {};
  options.format = 'text';

  /**
   * @private @const {!grpc.web.GrpcWebClientBase} The client
   */
  this.client_ = new grpc.web.GrpcWebClientBase(options);

  /**
   * @private @const {string} The hostname
   */
  this.hostname_ = hostname.replace(/\/+$/, '');

};


/**
 * @const
 * @type {!grpc.web.MethodDescriptor<
 *   !proto.order.Order,
 *   !proto.order.OrderId>}
 */
const methodDescriptor_OrderTransactionProvider_NewOrderTrans = new grpc.web.MethodDescriptor(
  '/order.OrderTransactionProvider/NewOrderTrans',
  grpc.web.MethodType.UNARY,
  proto.order.Order,
  proto.order.OrderId,
  /**
   * @param {!proto.order.Order} request
   * @return {!Uint8Array}
   */
  function(request) {
    return request.serializeBinary();
  },
  proto.order.OrderId.deserializeBinary
);


/**
 * @param {!proto.order.Order} request The
 *     request proto
 * @param {?Object<string, string>} metadata User defined
 *     call metadata
 * @param {function(?grpc.web.RpcError, ?proto.order.OrderId)}
 *     callback The callback function(error, response)
 * @return {!grpc.web.ClientReadableStream<!proto.order.OrderId>|undefined}
 *     The XHR Node Readable Stream
 */
proto.order.OrderTransactionProviderClient.prototype.newOrderTrans =
    function(request, metadata, callback) {
  return this.client_.rpcCall(this.hostname_ +
      '/order.OrderTransactionProvider/NewOrderTrans',
      request,
      metadata || {},
      methodDescriptor_OrderTransactionProvider_NewOrderTrans,
      callback);
};


/**
 * @param {!proto.order.Order} request The
 *     request proto
 * @param {?Object<string, string>=} metadata User defined
 *     call metadata
 * @return {!Promise<!proto.order.OrderId>}
 *     Promise that resolves to the response
 */
proto.order.OrderTransactionProviderPromiseClient.prototype.newOrderTrans =
    function(request, metadata) {
  return this.client_.unaryCall(this.hostname_ +
      '/order.OrderTransactionProvider/NewOrderTrans',
      request,
      metadata || {},
      methodDescriptor_OrderTransactionProvider_NewOrderTrans);
};


/**
 * @const
 * @type {!grpc.web.MethodDescriptor<
 *   !proto.order.OrderId,
 *   !proto.order.OrderId>}
 */
const methodDescriptor_OrderTransactionProvider_CancelOrderTrans = new grpc.web.MethodDescriptor(
  '/order.OrderTransactionProvider/CancelOrderTrans',
  grpc.web.MethodType.UNARY,
  proto.order.OrderId,
  proto.order.OrderId,
  /**
   * @param {!proto.order.OrderId} request
   * @return {!Uint8Array}
   */
  function(request) {
    return request.serializeBinary();
  },
  proto.order.OrderId.deserializeBinary
);


/**
 * @param {!proto.order.OrderId} request The
 *     request proto
 * @param {?Object<string, string>} metadata User defined
 *     call metadata
 * @param {function(?grpc.web.RpcError, ?proto.order.OrderId)}
 *     callback The callback function(error, response)
 * @return {!grpc.web.ClientReadableStream<!proto.order.OrderId>|undefined}
 *     The XHR Node Readable Stream
 */
proto.order.OrderTransactionProviderClient.prototype.cancelOrderTrans =
    function(request, metadata, callback) {
  return this.client_.rpcCall(this.hostname_ +
      '/order.OrderTransactionProvider/CancelOrderTrans',
      request,
      metadata || {},
      methodDescriptor_OrderTransactionProvider_CancelOrderTrans,
      callback);
};


/**
 * @param {!proto.order.OrderId} request The
 *     request proto
 * @param {?Object<string, string>=} metadata User defined
 *     call metadata
 * @return {!Promise<!proto.order.OrderId>}
 *     Promise that resolves to the response
 */
proto.order.OrderTransactionProviderPromiseClient.prototype.cancelOrderTrans =
    function(request, metadata) {
  return this.client_.unaryCall(this.hostname_ +
      '/order.OrderTransactionProvider/CancelOrderTrans',
      request,
      metadata || {},
      methodDescriptor_OrderTransactionProvider_CancelOrderTrans);
};


/**
 * @const
 * @type {!grpc.web.MethodDescriptor<
 *   !proto.order.Fill,
 *   !proto.order.FillId>}
 */
const methodDescriptor_OrderTransactionProvider_NewFillTrans = new grpc.web.MethodDescriptor(
  '/order.OrderTransactionProvider/NewFillTrans',
  grpc.web.MethodType.UNARY,
  proto.order.Fill,
  proto.order.FillId,
  /**
   * @param {!proto.order.Fill} request
   * @return {!Uint8Array}
   */
  function(request) {
    return request.serializeBinary();
  },
  proto.order.FillId.deserializeBinary
);


/**
 * @param {!proto.order.Fill} request The
 *     request proto
 * @param {?Object<string, string>} metadata User defined
 *     call metadata
 * @param {function(?grpc.web.RpcError, ?proto.order.FillId)}
 *     callback The callback function(error, response)
 * @return {!grpc.web.ClientReadableStream<!proto.order.FillId>|undefined}
 *     The XHR Node Readable Stream
 */
proto.order.OrderTransactionProviderClient.prototype.newFillTrans =
    function(request, metadata, callback) {
  return this.client_.rpcCall(this.hostname_ +
      '/order.OrderTransactionProvider/NewFillTrans',
      request,
      metadata || {},
      methodDescriptor_OrderTransactionProvider_NewFillTrans,
      callback);
};


/**
 * @param {!proto.order.Fill} request The
 *     request proto
 * @param {?Object<string, string>=} metadata User defined
 *     call metadata
 * @return {!Promise<!proto.order.FillId>}
 *     Promise that resolves to the response
 */
proto.order.OrderTransactionProviderPromiseClient.prototype.newFillTrans =
    function(request, metadata) {
  return this.client_.unaryCall(this.hostname_ +
      '/order.OrderTransactionProvider/NewFillTrans',
      request,
      metadata || {},
      methodDescriptor_OrderTransactionProvider_NewFillTrans);
};


module.exports = proto.order;

