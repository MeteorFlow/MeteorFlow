import "./Button.css";

type ButtonProps = {
    text?: string,
    className?: string,
    onClick?: () => void
}
export const Button: React.FC<ButtonProps> = ({text, className, onClick}) => {
    return(
        <button className={`${className} button`} onClick={onClick}>{text}</button>
    )
}