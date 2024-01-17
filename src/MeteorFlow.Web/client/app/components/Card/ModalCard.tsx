import { Button } from "../Button/Button";
import { useEffect, useRef, useState } from 'react';
import { Flex, Modal, Tag } from 'antd';
import { ProductDetail } from "../../pages/ProductDetail/ProductDetail";
import "./Card.css";
import * as React from "react";
import cardImg from "../../../assets/apple.png";

const ItemDetail={
    productId: "1",
    productName: "Apples",
    unit: "1lb",
    description: "An apple is a sweet, edible fruit produced by an apple tree (Malus domestica). Apple trees are ... The skin of ripe apples is generally red, yellow, green, pink, or russetted, though many bi- or tri-colored cultivars may be found.",
    price: "2.00",
    salePrice: "1.60",
    discountPercent: "20%",
    available: "18 pieces",
    categories: ["fruits & vegetables", "fruits"],
    seller: "Grocery Shop",
    rate: {rating: 4.67, ratingStar: [2, 1, 0, 0, 0], ratingNumber: 3},
    image: ["https://5.imimg.com/data5/AK/RA/MY-68428614/apple-500x500.jpg",
    "https://post.healthline.com/wp-content/uploads/2020/09/health-benefits-of-apples-732x549-thumbnail-732x549.jpg", 
    "https://assets.woolworths.com.au/images/2010/155003.jpg?impolicy=wowcdxwbjbx&w=900&h=900", 
    "https://minchinburyfruitmarket.com.au/content/images/thumbs/0000570_apple-red-delicious-lge_400.jpeg"],
}

type CardProps = {
    productId: string
}
export const CardWithModal: React.FC<CardProps> = ({productId}) => {
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [quantity, setQuantity] = useState<number>(0);

    const showModal = () => {
        setIsModalOpen(true);
    };
    
    const handleOk = () => {
        setIsModalOpen(false);
        console.log('ok');
    };
    
    const handleCancel = () => {
        setIsModalOpen(false);
        console.log('cancel');
    };

    const handleAddProduct = () => {
        setQuantity(quantity + 1);
    }

    const handleSubProduct = () => {
        setQuantity(quantity - 1);
    }

    return (
        <Flex className="ProductCard" vertical >
            <div className="ProductCard--Image"  onClick={showModal}>
                {ItemDetail.discountPercent && <Tag color="#009f7f">{ItemDetail.discountPercent}</Tag>}
                <img src={cardImg} alt="product image"/>
            </div>
            <Flex vertical gap="small" align="flex-start" style={{ padding: '20px'}}>
                {
                    ItemDetail.salePrice ? 
                    <Flex gap="small" align="center">
                        <span style={{ fontWeight: '600', fontSize: '18px'}}>${ItemDetail.salePrice}</span>
                        <span style={{ textDecoration: 'line-through', opacity: '0.5', fontSize: '14px'}} > ${ItemDetail.price}</span>
                    </Flex>
                    : <span style={{ fontWeight: '600', fontSize: '20px'}}>${ItemDetail.price}</span>
                }
                <span style={{ opacity: '0.8', fontSize: '16px'}}>{ItemDetail.productName}</span>
                {
                    quantity === 0 ?
                    <button className="ProductCard--button" onClick={handleAddProduct}>
                        <span className="ProductCard--button__add">
                            Add
                        </span>
                        <span className="ProductCard--button__addIcon">
                            +
                        </span>
                    </button> :
                    <button className="ProductCard--button">
                        <span className="ProductCard--button__icon leftIcon" onClick={handleSubProduct}>
                            -
                        </span>
                        <span className="ProductCard--button__quantity">
                            {quantity}
                        </span>
                        <span className="ProductCard--button__icon rightIcon" onClick={handleAddProduct}>
                            +
                        </span>
                    </button>
                }
            </Flex>
            <Modal open={isModalOpen} onOk={handleOk} onCancel={handleCancel} footer={null} width="75%" >
                <ProductDetail productId={productId}/>
            </Modal>
        </Flex>
    )
}