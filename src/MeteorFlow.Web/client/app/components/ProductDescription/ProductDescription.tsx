import { HeartOutlined, StarFilled } from "@ant-design/icons";
import { Flex, Tag } from "antd";
import { useState } from "react";
import { NavLink } from "react-router-dom";
import { Button } from "../Button/Button";
// import { Rating } from "../Rating/Rating";
import "./ProductDescription.css";

type ProductDescriptionProps = {
    productInfo:{
        productId: string;
        title: string;
        unit: string;
        description: string;
        price: string;
        salePrice?: string;
        available: string;
        categories: string[];
        seller: string;
        rate: {rating: number; ratingStar: number[], ratingNumber: number};
        image: string[];
    }
}

export const ProductDescription: React.FC<ProductDescriptionProps> = (props) => {
    const {productInfo: {productId, title, unit, description, price, salePrice, available, categories, seller,  rate, image}} = props;
    const [imageIdx, setImageIdx] = useState<number>(0);
    const [heart, setHeart] = useState<boolean>(false);

    const handleLike = () => {
        setHeart(!heart);
    }

    const handleAdd = () => {
        console.log("Add");
    }
    
    const handleClickTitle = () => {
        window.location.href = "../products";   
    }
    return(
    <div className="productDescription">
        <div className="ProductDetail--Description">
            <Flex className="ProductImage" vertical>
                <div className="ProductImage--Container">
                    <img className="ProductImage--MainImage" src={image[imageIdx]} alt = "ProductImage" />
                </div>
                <Flex gap="small" justify="space-between">
                    {image.map((item, index) => {
                        return(
                            <img className={`ProductImage--SmallImage${index === imageIdx ? "__selected" : ""}`} src={item} alt = "ProductImage" onClick={() => setImageIdx(index)}/>
                        )
                    })}
                </Flex>
            </Flex>
            <Flex className="ProductInfo" vertical gap="large"> 
                <Flex className="ProductInfo--Detail" vertical gap="small"> 
                    <Flex justify="space-between" align="center">
                        <span className="ProductTitle" onClick={handleClickTitle}>{title}</span>                   
                        <button className="heart" onClick={handleLike} ><HeartOutlined style={{ color: '#009f7f' }} /></button>
                    </Flex>
                    <Flex justify="space-between">
                        <span style={{ fontSize: '14px', opacity: '0.7'}}>{unit}</span>
                        <Tag color="#009f7f" style={{fontSize: '14px',  margin: "0"}}>{rate.rating} <StarFilled /></Tag>
                    </Flex>
                    <span>{description}</span>
                    <Flex gap="small" align="center">
                        <span style={{ fontWeight: '600', fontSize: '30px', color: '#009f7f' }}>${salePrice}</span>
                        <span style={{ textDecoration: 'line-through', opacity: '0.7'}} > ${price}</span>
                    </Flex>
                    <Flex align="center" gap="large">
                        <Button className="AddCartButton" text="Add To Shopping Cart" onClick={handleAdd} />
                        <span style={{ fontSize: '16px', opacity: '0.7'}} >{available} available</span>
                    </Flex>
                </Flex>
                <Flex vertical justify="center" gap="large">
                    <Flex align="center">
                        <span style={{ fontWeight: 'bolder', marginRight: '10px' }} >Categories:</span>
                        {categories.map((category) => {
                            return(
                                <Tag color="cyan">{category}</Tag>
                            )
                        })}
                    </Flex>
                    <Flex align="center">
                        <span style={{ fontWeight: 'bolder', marginRight: '10px' }}>Sellers:</span>
                        <NavLink to="/shop-product" style={{ color: '#009f7f', textDecoration: 'underline' }}>{seller}</NavLink>
                    </Flex>
                </Flex>
            </Flex>
        </div>
        <Flex className="ProductDetail--Detail" vertical gap="large">
            <span style={{fontWeight: "bolder", fontSize: "20px"}}>Details</span>
            <span>{description}</span>
        </Flex> 
    </div>
    )
}