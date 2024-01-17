import "./ProductList.css";
import { Card } from '../../components/Card/Card';
import productImage from "../../../assets/apple.png";
import { Button } from "../Button/Button";
import { Flex, Modal } from "antd";
import { useState } from "react";
import { ProductDetail } from "../../pages/ProductDetail/ProductDetail";
import { CardWithModal } from "../Card/ModalCard";
import ProductCard from "../ProductCard/ProductCard";
import ProductCardTwo from "../ProductCard/ProductCardTwo";


const Products = [
    {
        productId: "1",
        productImage: productImage,
    },
    {
        productId: "2",
        productImage: productImage,
    },
    {
        productId: "3",
        productImage: productImage,
    },
    {
        productId: "4",
        productImage: productImage,
    },
    {
        productId: "5",
        productImage: productImage,
    },
    {
        productId: "6",
        productImage: productImage,
    },    
    {
        productId: "7",
        productImage: productImage,
    },
    {
        productId: "8",
        productImage: productImage,
    },
    {
        productId: "9",
        productImage: productImage,
    },
    {
        productId: "10",
        productImage: productImage,
    },     
    {
        productId: "11",
        productImage: productImage,
    },
    {
        productId: "12",
        productImage: productImage,
    }
]

type ProductListProps = {
    categoryId?: string,
    shopId?: string,
}

export const ProductList: React.FC<ProductListProps> = ({categoryId, shopId}) => {
    
    const handleLoading = () => {
        console.log('Loading');
    }
    return (
        <div className="ProductList">
            <Flex className="ProductList--products" gap="large" align="center" vertical >
                <Flex  wrap="wrap" gap="small" justify="space-between">
                    {Products.map(item => 
                        <CardWithModal productId="1"/>
                    )}
                </Flex>
                <Button text='Load More' onClick={handleLoading}/>
            </Flex>
        </div>
    )
}