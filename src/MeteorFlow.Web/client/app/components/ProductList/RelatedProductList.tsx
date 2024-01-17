import "./ProductList.css";
import { Card } from '../../components/Card/Card';
import productImage from "../../../assets/spinach.png";
import { Button } from "../Button/Button";
import { Flex } from "antd";
import ProductCardTwo from "../ProductCard/ProductCardTwo";
import ProductCard from "../ProductCard/ProductCard";

type RelatedProductListProps = {
    productId: string
}
export const RelatedProductList: React.FC<RelatedProductListProps> = ({productId}) => {
    const handleLoading = () => {
        console.log('Loading');
    }
    return (
        <Flex className="RelatedProductList" wrap="wrap" gap="small" justify="space-between">
            <Card productId='1'/>
            <Card productId='2'/>
            <Card productId='3'/>
            <Card productId='4'/>
            <Card productId='5'/>
            <Card productId='6'/>
            <Card productId='7'/>
            <Card productId='8'/>
            <Card productId='9'/>
            <Card productId='10'/>
        </Flex>
    )
}