
import '../../scss/main.scss';
interface navOptions {
    firstName: string;
    middleName?: string;
    lastName: string;
};
const refreshList = async () => {
    //console.log(process.env.REACT_APP_API+"Department")
    fetch(process.env.REACT_APP_API + 'Department?DepartmentID=1&DepartmentName=1')
        .then(response=>response.json())
        .then(data=>{
            console.log(data)
        });
}
const NavMain = ({ firstName, middleName, lastName }:navOptions) => {
    return (
      <nav className='nav-main'>
            <button className='nav--main-button' onClick={refreshList}>Test</button>
            <button className='nav--main-button'>Test</button>
            <button className='nav--main-button'>Test</button>
    </nav>  
    )
    
}
export { NavMain }