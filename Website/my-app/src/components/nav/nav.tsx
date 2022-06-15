import { Component, Key, Suspense, useEffect } from "react";
import "../../scss/main.scss";
interface navOptions {
  firstName: string;
  middleName?: string;
  lastName: string;
}
interface ListingOptions {
  props: {
    DepartmentID: Array<number>;
    DepartmentName: Array<string>;
  };
}
class Listing extends Component<{}, { Data: any }> {
  DepartmentID: [];
  DepartmentName: [];
  DataWrapper: { DepartmentID: Array<number>; DepartmentName: Array<string> };
  constructor({ props }: ListingOptions) {
    super(props);
    this.DepartmentID = [];
    this.DepartmentName = [];
    this.DataWrapper = { DepartmentID: [], DepartmentName: [] };
    this.state = {
      Data: {},
    };
  }

  componentDidMount() {
    //console.log(this.props, this.DepartmentID, "My record")

    fetch(
      process.env.REACT_APP_API + "Department?DepartmentID=1&DepartmentName=1"
    )
      .then((response) => response.json())
      .then((data: [number, string]) => {
        //console.log(data, 'Fetch in Listing component')
        this.DataWrapper.DepartmentID.push(data[0]);
        this.DataWrapper.DepartmentName.push(data[1]);
        //console.log(this.DataWrapper,  "Data wrapper");
        this.setState({
          Data: this.DataWrapper,
        });
        this.renderList();
        return;
      })
      .catch((error) => console.log("Error!"));
  }
  renderList() {
    setTimeout(() => {
      let DepartmentName: Array<string> = [];
      console.log(this.state.Data);
      this.state.Data.DepartmentName.map((record: string) => {
        DepartmentName.push(record);
      });
      console.log(DepartmentName, "departmentName");
      return DepartmentName;
    });
  }
  render() {
    //console.log([x, this.DataWrapper.DepartmentName[i]])

    return <p>fds</p>;
  }
}

const refreshList = async () => {
  //console.log(process.env.REACT_APP_API+"Department")
  fetch(
    process.env.REACT_APP_API + "Department?DepartmentID=1&DepartmentName=1"
  )
    .then((response) => response.json())
    .then((data) => {
      console.log(data);
      return data;
    })
    .catch((error) => console.log("Error!"));
};
const NavMain = ({ firstName, middleName, lastName }: navOptions) => {
  return (
    <nav className="nav-main">
      <button className="nav--main-button" onClick={refreshList}>
        Test
      </button>
      <button className="nav--main-button">Test</button>
      <button className="nav--main-button">Test</button>
    </nav>
  );
};
export { NavMain, Listing };
