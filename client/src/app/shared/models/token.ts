export interface IToken {
  id: number;
  tokenUid: string;
  donator: string;
  userId: number;
  tokenName: string;
  store: string;
  productType: string;
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
