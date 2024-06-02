
export interface ProductTag {
  value: string;
}

export interface Product {
  productId: number;
  name: string;
  tags: ProductTag[];
}

export interface DeleteManyProductsArgs {
  productIds: number[]
}
