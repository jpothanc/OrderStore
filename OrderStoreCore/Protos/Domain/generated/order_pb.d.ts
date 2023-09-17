import * as jspb from 'google-protobuf'

import * as google_protobuf_timestamp_pb from 'google-protobuf/google/protobuf/timestamp_pb';


export class OrderId extends jspb.Message {
  getOrderid(): string;
  setOrderid(value: string): OrderId;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): OrderId.AsObject;
  static toObject(includeInstance: boolean, msg: OrderId): OrderId.AsObject;
  static serializeBinaryToWriter(message: OrderId, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): OrderId;
  static deserializeBinaryFromReader(message: OrderId, reader: jspb.BinaryReader): OrderId;
}

export namespace OrderId {
  export type AsObject = {
    orderid: string,
  }
}

export class FillId extends jspb.Message {
  getFillid(): string;
  setFillid(value: string): FillId;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): FillId.AsObject;
  static toObject(includeInstance: boolean, msg: FillId): FillId.AsObject;
  static serializeBinaryToWriter(message: FillId, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): FillId;
  static deserializeBinaryFromReader(message: FillId, reader: jspb.BinaryReader): FillId;
}

export namespace FillId {
  export type AsObject = {
    fillid: string,
  }
}

export class OrderRequest extends jspb.Message {
  getOrderid(): string;
  setOrderid(value: string): OrderRequest;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): OrderRequest.AsObject;
  static toObject(includeInstance: boolean, msg: OrderRequest): OrderRequest.AsObject;
  static serializeBinaryToWriter(message: OrderRequest, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): OrderRequest;
  static deserializeBinaryFromReader(message: OrderRequest, reader: jspb.BinaryReader): OrderRequest;
}

export namespace OrderRequest {
  export type AsObject = {
    orderid: string,
  }
}

export class OrderResponse extends jspb.Message {
  getOrder(): Order | undefined;
  setOrder(value?: Order): OrderResponse;
  hasOrder(): boolean;
  clearOrder(): OrderResponse;

  getHasvalue(): boolean;
  setHasvalue(value: boolean): OrderResponse;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): OrderResponse.AsObject;
  static toObject(includeInstance: boolean, msg: OrderResponse): OrderResponse.AsObject;
  static serializeBinaryToWriter(message: OrderResponse, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): OrderResponse;
  static deserializeBinaryFromReader(message: OrderResponse, reader: jspb.BinaryReader): OrderResponse;
}

export namespace OrderResponse {
  export type AsObject = {
    order?: Order.AsObject,
    hasvalue: boolean,
  }
}

export class Order extends jspb.Message {
  getOrderid(): string;
  setOrderid(value: string): Order;

  getParentorderid(): string;
  setParentorderid(value: string): Order;

  getState(): State;
  setState(value: State): Order;

  getProduct(): string;
  setProduct(value: string): Order;

  getSize(): number;
  setSize(value: number): Order;

  getQdone(): number;
  setQdone(value: number): Order;

  getPrice(): string;
  setPrice(value: string): Order;

  getAcronym(): string;
  setAcronym(value: string): Order;

  getAccount(): string;
  setAccount(value: string): Order;

  getTxfaccount(): string;
  setTxfaccount(value: string): Order;

  getEntity(): string;
  setEntity(value: string): Order;

  getOstamp(): google_protobuf_timestamp_pb.Timestamp | undefined;
  setOstamp(value?: google_protobuf_timestamp_pb.Timestamp): Order;
  hasOstamp(): boolean;
  clearOstamp(): Order;

  getCstamp(): google_protobuf_timestamp_pb.Timestamp | undefined;
  setCstamp(value?: google_protobuf_timestamp_pb.Timestamp): Order;
  hasCstamp(): boolean;
  clearCstamp(): Order;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): Order.AsObject;
  static toObject(includeInstance: boolean, msg: Order): Order.AsObject;
  static serializeBinaryToWriter(message: Order, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): Order;
  static deserializeBinaryFromReader(message: Order, reader: jspb.BinaryReader): Order;
}

export namespace Order {
  export type AsObject = {
    orderid: string,
    parentorderid: string,
    state: State,
    product: string,
    size: number,
    qdone: number,
    price: string,
    acronym: string,
    account: string,
    txfaccount: string,
    entity: string,
    ostamp?: google_protobuf_timestamp_pb.Timestamp.AsObject,
    cstamp?: google_protobuf_timestamp_pb.Timestamp.AsObject,
  }
}

export class Fill extends jspb.Message {
  getOrderid(): string;
  setOrderid(value: string): Fill;

  getFillid(): string;
  setFillid(value: string): Fill;

  getParentfillid(): string;
  setParentfillid(value: string): Fill;

  getState(): State;
  setState(value: State): Fill;

  getProduct(): string;
  setProduct(value: string): Fill;

  getSize(): number;
  setSize(value: number): Fill;

  getPrice(): string;
  setPrice(value: string): Fill;

  getCbrk(): string;
  setCbrk(value: string): Fill;

  getCpty(): string;
  setCpty(value: string): Fill;

  getFstamp(): google_protobuf_timestamp_pb.Timestamp | undefined;
  setFstamp(value?: google_protobuf_timestamp_pb.Timestamp): Fill;
  hasFstamp(): boolean;
  clearFstamp(): Fill;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): Fill.AsObject;
  static toObject(includeInstance: boolean, msg: Fill): Fill.AsObject;
  static serializeBinaryToWriter(message: Fill, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): Fill;
  static deserializeBinaryFromReader(message: Fill, reader: jspb.BinaryReader): Fill;
}

export namespace Fill {
  export type AsObject = {
    orderid: string,
    fillid: string,
    parentfillid: string,
    state: State,
    product: string,
    size: number,
    price: string,
    cbrk: string,
    cpty: string,
    fstamp?: google_protobuf_timestamp_pb.Timestamp.AsObject,
  }
}

export class OrderCriteria extends jspb.Message {
  getCriteria(): string;
  setCriteria(value: string): OrderCriteria;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): OrderCriteria.AsObject;
  static toObject(includeInstance: boolean, msg: OrderCriteria): OrderCriteria.AsObject;
  static serializeBinaryToWriter(message: OrderCriteria, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): OrderCriteria;
  static deserializeBinaryFromReader(message: OrderCriteria, reader: jspb.BinaryReader): OrderCriteria;
}

export namespace OrderCriteria {
  export type AsObject = {
    criteria: string,
  }
}

export class FillCriteria extends jspb.Message {
  getCriteria(): string;
  setCriteria(value: string): FillCriteria;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): FillCriteria.AsObject;
  static toObject(includeInstance: boolean, msg: FillCriteria): FillCriteria.AsObject;
  static serializeBinaryToWriter(message: FillCriteria, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): FillCriteria;
  static deserializeBinaryFromReader(message: FillCriteria, reader: jspb.BinaryReader): FillCriteria;
}

export namespace FillCriteria {
  export type AsObject = {
    criteria: string,
  }
}

export enum State { 
  LIVE = 0,
  FILLED = 1,
  BOOKED = 2,
  CXL = 3,
  CLOSED = 4,
}
export enum TransType { 
  NO = 0,
  UP = 1,
  NF = 2,
  ND = 3,
}
