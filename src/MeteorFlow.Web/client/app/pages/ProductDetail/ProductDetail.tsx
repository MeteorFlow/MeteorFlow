import "./ProductDetail.css";
import "../../App.css";
import { Flex, Tag } from "antd";
import { useState } from "react";
import { Button } from "../../components/Button/Button";
import {StarFilled, HeartOutlined} from '@ant-design/icons';
import { RelatedProductList } from "../../components/ProductList/RelatedProductList";
import { ProductDescription } from "../../components/ProductDescription/ProductDescription";

type ProductDetailProps = {
    productId: string
}

const ItemDetail=[
    {
        productId: "1",
        title: "Apples",
        unit: "1lb",
        description: "An apple is a sweet, edible fruit produced by an apple tree (Malus domestica). Apple trees are ... The skin of ripe apples is generally red, yellow, green, pink, or russetted, though many bi- or tri-colored cultivars may be found.",
        price: "2.00",
        salePrice: "1.60",
        available: "18 pieces",
        categories: ["fruits & vegetables", "fruits"],
        seller: "Grocery Shop",
        rate: {rating: 4.67, ratingStar: [2, 1, 0, 0, 0], ratingNumber: 3},
        image: ["https://5.imimg.com/data5/AK/RA/MY-68428614/apple-500x500.jpg",
        "https://post.healthline.com/wp-content/uploads/2020/09/health-benefits-of-apples-732x549-thumbnail-732x549.jpg", 
        "https://assets.woolworths.com.au/images/2010/155003.jpg?impolicy=wowcdxwbjbx&w=900&h=900", 
        "https://minchinburyfruitmarket.com.au/content/images/thumbs/0000570_apple-red-delicious-lge_400.jpeg"]
    },
    {
        productId: "2",
        title: "Spinach",
        unit: "1lb",
        description: "An apple is a sweet, edible fruit produced by an apple tree (Malus domestica). Apple trees are ... The skin of ripe apples is generally red, yellow, green, pink, or russetted, though many bi- or tri-colored cultivars may be found.",
        price: "2.00",
        salePrice: "1.60",
        available: "18 pieces",
        categories: ["fruits & vegetables", "fruits"],
        seller: "Grocery Shop",
        rate: {rating: 4.67, ratingStar: [2, 1, 0, 0, 0], ratingNumber: 3},
        image: ["https://assets.woolworths.com.au/images/2010/155003.jpg?impolicy=wowcdxwbjbx&w=900&h=900", 
        "https://post.healthline.com/wp-content/uploads/2020/09/health-benefits-of-apples-732x549-thumbnail-732x549.jpg", 
        "https://5.imimg.com/data5/AK/RA/MY-68428614/apple-500x500.jpg",
         "https://minchinburyfruitmarket.com.au/content/images/thumbs/0000570_apple-red-delicious-lge_400.jpeg"]
    }
]


export const ProductDetail: React.FC<ProductDetailProps> = ({productId}) => {
    const [selectedProduct, setSelectedProduct] = useState<number>(0);

    return (
        <div className="ProductDetail">
            <ProductDescription productInfo={ItemDetail[parseInt(selectedProduct)]}/>
            <Flex className="ProductDetail--Related" vertical gap="large">
                <span style={{fontWeight: "bolder", fontSize: "20px"}}>Related Products</span>
            <RelatedProductList productId={ItemDetail[parseInt(selectedProduct)].productId} />
            </Flex> 
        </div>
    );
}