export interface IToken {
  id: number;
  tokenUid: string;
  donator: string;
  tokenName: string;
  buyerEmail: string,
  storeName: string;
  productTypeName: string;
  productName: string;
  recipient: string;
  costPrice: number;
  salesPrice: number;
  dateCreated: Date;
  dateStoreAssigned: Date;
  dateAssigned: Date;
  dateCollected: Date;
  dateRelease: Date;
  dateExpire: Date;
  foodCollected: boolean;
  valid: boolean;
  imageUrl: string;
  shortUrl: string;
  recipientName: string;
  donatorName: string;
}
