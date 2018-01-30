// 源文件头信息：
// <copyright file="ExpressionSerializer (GenerateXmlFromExpressionCore).cs">
// Copyright(c)2012-2012 EBOOOY.All rights reserved.
// CLR版本：4.0.30319.239




// 创建时间：2012/04/08 6:49
// 最后修改：2012/04/08 7:49
// </copyright>

using System;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Metro.DynamicModeules.Common.ExpressionSerialization
{
    //GenerateXmlFromExpressionCore
    public partial class ExpressionSerializer
    {
        public XElement GenerateXmlFromExpressionCore(Expression e)
        {
            XElement replace;
            if (e == null)
            {
                return null;
            }
            if (TryCustomSerializers(e, out replace))
            {
                return replace;
            }
            if (e is BinaryExpression)
            {
                return BinaryExpressionToXElement((BinaryExpression)e);
            }

            if (e is BlockExpression)
            {
                return BlockExpressionToXElement((BlockExpression)e);
            }

            if (e is ConditionalExpression)
            {
                return ConditionalExpressionToXElement((ConditionalExpression)e);
            }

            if (e is ConstantExpression)
            {
                return ConstantExpressionToXElement((ConstantExpression)e);
            }

            if (e is DebugInfoExpression)
            {
                return DebugInfoExpressionToXElement((DebugInfoExpression)e);
            }

            if (e is DefaultExpression)
            {
                return DefaultExpressionToXElement((DefaultExpression)e);
            }

            if (e is DynamicExpression)
            {
                return DynamicExpressionToXElement((DynamicExpression)e);
            }

            if (e is GotoExpression)
            {
                return GotoExpressionToXElement((GotoExpression)e);
            }

            if (e is IndexExpression)
            {
                return IndexExpressionToXElement((IndexExpression)e);
            }

            if (e is InvocationExpression)
            {
                return InvocationExpressionToXElement((InvocationExpression)e);
            }

            if (e is LabelExpression)
            {
                return LabelExpressionToXElement((LabelExpression)e);
            }

            if (e is LambdaExpression)
            {
                return LambdaExpressionToXElement((LambdaExpression)e);
            }

            if (e is ListInitExpression)
            {
                return ListInitExpressionToXElement((ListInitExpression)e);
            }

            if (e is LoopExpression)
            {
                return LoopExpressionToXElement((LoopExpression)e);
            }

            if (e is MemberExpression)
            {
                return MemberExpressionToXElement((MemberExpression)e);
            }

            if (e is MemberInitExpression)
            {
                return MemberInitExpressionToXElement((MemberInitExpression)e);
            }

            if (e is MethodCallExpression)
            {
                return MethodCallExpressionToXElement((MethodCallExpression)e);
            }

            if (e is NewArrayExpression)
            {
                return NewArrayExpressionToXElement((NewArrayExpression)e);
            }

            if (e is NewExpression)
            {
                return NewExpressionToXElement((NewExpression)e);
            }

            if (e is ParameterExpression)
            {
                return ParameterExpressionToXElement((ParameterExpression)e);
            }

            if (e is RuntimeVariablesExpression)
            {
                return RuntimeVariablesExpressionToXElement((RuntimeVariablesExpression)e);
            }

            if (e is SwitchExpression)
            {
                return SwitchExpressionToXElement((SwitchExpression)e);
            }

            if (e is TryExpression)
            {
                return TryExpressionToXElement((TryExpression)e);
            }

            if (e is TypeBinaryExpression)
            {
                return TypeBinaryExpressionToXElement((TypeBinaryExpression)e);
            }

            if (e is UnaryExpression)
            {
                return UnaryExpressionToXElement((UnaryExpression)e);
            }
            return null;
        }

        //end GenerateXmlFromExpressionCore


        internal XElement BinaryExpressionToXElement(BinaryExpression e)
        {
            const string xName = "BinaryExpression";
            var xElementValues = new object[9];
            object value = (e).CanReduce;
            xElementValues[0] = GenerateXmlFromProperty(typeof(Boolean), "CanReduce", value);
            value = (e).Right;
            xElementValues[1] = GenerateXmlFromProperty(typeof(Expression), "Right", value ?? string.Empty);
            value = (e).Left;
            xElementValues[2] = GenerateXmlFromProperty(typeof(Expression), "Left", value ?? string.Empty);
            value = (e).Method;
            xElementValues[3] = GenerateXmlFromProperty(typeof(MethodInfo), "Method", value ?? string.Empty);
            value = (e).Conversion;
            xElementValues[4] = GenerateXmlFromProperty(typeof(LambdaExpression), "Conversion", value ?? string.Empty);
            value = (e).IsLifted;
            xElementValues[5] = GenerateXmlFromProperty(typeof(Boolean), "IsLifted", value ?? string.Empty);
            value = (e).IsLiftedToNull;
            xElementValues[6] = GenerateXmlFromProperty(typeof(Boolean), "IsLiftedToNull", value ?? string.Empty);
            value = (e).NodeType;
            xElementValues[7] = GenerateXmlFromProperty(typeof(ExpressionType), "NodeType", value ?? string.Empty);
            value = (e).Type;
            xElementValues[8] = GenerateXmlFromProperty(typeof(Type), "Type", value ?? string.Empty);
            return new XElement(xName, xElementValues);
        }

        //end static method
        internal XElement BlockExpressionToXElement(BlockExpression e)
        {
            const string xName = "BlockExpression";
            var xElementValues = new object[6];
            object value = (e).Expressions;
            xElementValues[0] = GenerateXmlFromProperty(typeof(ReadOnlyCollection<Expression>), "Expressions", value ?? string.Empty);
            value = (e).Variables;
            xElementValues[1] = GenerateXmlFromProperty(typeof(ReadOnlyCollection<ParameterExpression>), "Variables", value ?? string.Empty);
            value = (e).Result;
            xElementValues[2] = GenerateXmlFromProperty(typeof(Expression), "Result", value ?? string.Empty);
            value = (e).NodeType;
            xElementValues[3] = GenerateXmlFromProperty(typeof(ExpressionType), "NodeType", value ?? string.Empty);
            value = (e).Type;
            xElementValues[4] = GenerateXmlFromProperty(typeof(Type), "Type", value ?? string.Empty);
            value = (e).CanReduce;
            xElementValues[5] = GenerateXmlFromProperty(typeof(Boolean), "CanReduce", value ?? string.Empty);
            return new XElement(xName, xElementValues);
        }

        //end static method
        internal XElement ConditionalExpressionToXElement(ConditionalExpression e)
        {
            const string xName = "ConditionalExpression";
            var xElementValues = new object[6];
            object value = (e).NodeType;
            xElementValues[0] = GenerateXmlFromProperty(typeof(ExpressionType), "NodeType", value ?? string.Empty);
            value = (e).Type;
            xElementValues[1] = GenerateXmlFromProperty(typeof(Type), "Type", value ?? string.Empty);
            value = (e).Test;
            xElementValues[2] = GenerateXmlFromProperty(typeof(Expression), "Test", value ?? string.Empty);
            value = (e).IfTrue;
            xElementValues[3] = GenerateXmlFromProperty(typeof(Expression), "IfTrue", value ?? string.Empty);
            value = (e).IfFalse;
            xElementValues[4] = GenerateXmlFromProperty(typeof(Expression), "IfFalse", value ?? string.Empty);
            value = (e).CanReduce;
            xElementValues[5] = GenerateXmlFromProperty(typeof(Boolean), "CanReduce", value ?? string.Empty);
            return new XElement(xName, xElementValues);
        }

        //end static method
        internal XElement ConstantExpressionToXElement(ConstantExpression e)
        {
            object value;
            string xName = "ConstantExpression";
            var XElementValues = new object[4];
            value = (e).Type;
            XElementValues[0] = GenerateXmlFromProperty(typeof(Type), "Type", value ?? string.Empty);
            value = (e).NodeType;
            XElementValues[1] = GenerateXmlFromProperty(typeof(ExpressionType), "NodeType", value ?? string.Empty);
            value = (e).Value;
            XElementValues[2] = GenerateXmlFromProperty(typeof(Object), "Value", value ?? string.Empty);
            value = (e).CanReduce;
            XElementValues[3] = GenerateXmlFromProperty(typeof(Boolean), "CanReduce", value ?? string.Empty);
            return new XElement(xName, XElementValues);
        }

        //end static method
        internal XElement DebugInfoExpressionToXElement(DebugInfoExpression e)
        {
            object value;
            string xName = "DebugInfoExpression";
            var XElementValues = new object[9];
            value = (e).Type;
            XElementValues[0] = GenerateXmlFromProperty(typeof(Type), "Type", value ?? string.Empty);
            value = (e).NodeType;
            XElementValues[1] = GenerateXmlFromProperty(typeof(ExpressionType), "NodeType", value ?? string.Empty);
            value = (e).StartLine;
            XElementValues[2] = GenerateXmlFromProperty(typeof(Int32), "StartLine", value ?? string.Empty);
            value = (e).StartColumn;
            XElementValues[3] = GenerateXmlFromProperty(typeof(Int32), "StartColumn", value ?? string.Empty);
            value = (e).EndLine;
            XElementValues[4] = GenerateXmlFromProperty(typeof(Int32), "EndLine", value ?? string.Empty);
            value = (e).EndColumn;
            XElementValues[5] = GenerateXmlFromProperty(typeof(Int32), "EndColumn", value ?? string.Empty);
            value = (e).Document;
            XElementValues[6] = GenerateXmlFromProperty(typeof(SymbolDocumentInfo), "Document", value ?? string.Empty);
            value = (e).IsClear;
            XElementValues[7] = GenerateXmlFromProperty(typeof(Boolean), "IsClear", value ?? string.Empty);
            value = (e).CanReduce;
            XElementValues[8] = GenerateXmlFromProperty(typeof(Boolean), "CanReduce", value ?? string.Empty);
            return new XElement(xName, XElementValues);
        }

        //end static method
        internal XElement DefaultExpressionToXElement(DefaultExpression e)
        {
            object value;
            string xName = "DefaultExpression";
            var XElementValues = new object[3];
            value = (e).Type;
            XElementValues[0] = GenerateXmlFromProperty(typeof(Type), "Type", value ?? string.Empty);
            value = (e).NodeType;
            XElementValues[1] = GenerateXmlFromProperty(typeof(ExpressionType), "NodeType", value ?? string.Empty);
            value = (e).CanReduce;
            XElementValues[2] = GenerateXmlFromProperty(typeof(Boolean), "CanReduce", value ?? string.Empty);
            return new XElement(xName, XElementValues);
        }

        //end static method
        internal XElement DynamicExpressionToXElement(DynamicExpression e)
        {
            object value;
            string xName = "DynamicExpression";
            var XElementValues = new object[6];
            value = (e).Type;
            XElementValues[0] = GenerateXmlFromProperty(typeof(Type), "Type", value ?? string.Empty);
            value = (e).NodeType;
            XElementValues[1] = GenerateXmlFromProperty(typeof(ExpressionType), "NodeType", value ?? string.Empty);
            value = (e).Binder;
            XElementValues[2] = GenerateXmlFromProperty(typeof(CallSiteBinder), "Binder", value ?? string.Empty);
            value = (e).DelegateType;
            XElementValues[3] = GenerateXmlFromProperty(typeof(Type), "DelegateType", value ?? string.Empty);
            value = (e).Arguments;
            XElementValues[4] = GenerateXmlFromProperty(typeof(ReadOnlyCollection<Expression>), "Arguments", value ?? string.Empty);
            value = (e).CanReduce;
            XElementValues[5] = GenerateXmlFromProperty(typeof(Boolean), "CanReduce", value ?? string.Empty);
            return new XElement(xName, XElementValues);
        }

        //end static method
        internal XElement GotoExpressionToXElement(GotoExpression e)
        {
            object value;
            string xName = "GotoExpression";
            var XElementValues = new object[6];
            value = (e).Type;
            XElementValues[0] = GenerateXmlFromProperty(typeof(Type), "Type", value ?? string.Empty);
            value = (e).NodeType;
            XElementValues[1] = GenerateXmlFromProperty(typeof(ExpressionType), "NodeType", value ?? string.Empty);
            value = (e).Value;
            XElementValues[2] = GenerateXmlFromProperty(typeof(Expression), "Value", value ?? string.Empty);
            value = (e).Target;
            XElementValues[3] = GenerateXmlFromProperty(typeof(LabelTarget), "Target", value ?? string.Empty);
            value = (e).Kind;
            XElementValues[4] = GenerateXmlFromProperty(typeof(GotoExpressionKind), "Kind", value ?? string.Empty);
            value = (e).CanReduce;
            XElementValues[5] = GenerateXmlFromProperty(typeof(Boolean), "CanReduce", value ?? string.Empty);
            return new XElement(xName, XElementValues);
        }

        //end static method
        internal XElement IndexExpressionToXElement(IndexExpression e)
        {
            object value;
            string xName = "IndexExpression";
            var XElementValues = new object[6];
            value = (e).NodeType;
            XElementValues[0] = GenerateXmlFromProperty(typeof(ExpressionType), "NodeType", value ?? string.Empty);
            value = (e).Type;
            XElementValues[1] = GenerateXmlFromProperty(typeof(Type), "Type", value ?? string.Empty);
            value = (e).Object;
            XElementValues[2] = GenerateXmlFromProperty(typeof(Expression), "Object", value ?? string.Empty);
            value = (e).Indexer;
            XElementValues[3] = GenerateXmlFromProperty(typeof(PropertyInfo), "Indexer", value ?? string.Empty);
            value = (e).Arguments;
            XElementValues[4] = GenerateXmlFromProperty(typeof(ReadOnlyCollection<Expression>), "Arguments", value ?? string.Empty);
            value = (e).CanReduce;
            XElementValues[5] = GenerateXmlFromProperty(typeof(Boolean), "CanReduce", value ?? string.Empty);
            return new XElement(xName, XElementValues);
        }

        //end static method
        internal XElement InvocationExpressionToXElement(InvocationExpression e)
        {
            object value;
            string xName = "InvocationExpression";
            var XElementValues = new object[5];
            value = (e).Type;
            XElementValues[0] = GenerateXmlFromProperty(typeof(Type), "Type", value ?? string.Empty);
            value = (e).NodeType;
            XElementValues[1] = GenerateXmlFromProperty(typeof(ExpressionType), "NodeType", value ?? string.Empty);
            value = (e).Expression;
            XElementValues[2] = GenerateXmlFromProperty(typeof(Expression), "Expression", value ?? string.Empty);
            value = (e).Arguments;
            XElementValues[3] = GenerateXmlFromProperty(typeof(ReadOnlyCollection<Expression>), "Arguments", value ?? string.Empty);
            value = (e).CanReduce;
            XElementValues[4] = GenerateXmlFromProperty(typeof(Boolean), "CanReduce", value ?? string.Empty);
            return new XElement(xName, XElementValues);
        }

        //end static method
        internal XElement LabelExpressionToXElement(LabelExpression e)
        {
            object value;
            string xName = "LabelExpression";
            var XElementValues = new object[5];
            value = (e).Type;
            XElementValues[0] = GenerateXmlFromProperty(typeof(Type), "Type", value ?? string.Empty);
            value = (e).NodeType;
            XElementValues[1] = GenerateXmlFromProperty(typeof(ExpressionType), "NodeType", value ?? string.Empty);
            value = (e).Target;
            XElementValues[2] = GenerateXmlFromProperty(typeof(LabelTarget), "Target", value ?? string.Empty);
            value = (e).DefaultValue;
            XElementValues[3] = GenerateXmlFromProperty(typeof(Expression), "DefaultValue", value ?? string.Empty);
            value = (e).CanReduce;
            XElementValues[4] = GenerateXmlFromProperty(typeof(Boolean), "CanReduce", value ?? string.Empty);
            return new XElement(xName, XElementValues);
        }

        //end static method
        internal XElement LambdaExpressionToXElement(LambdaExpression e)
        {
            object value;
            string xName = "LambdaExpression";
            var XElementValues = new object[8];
            value = (e).Type;
            XElementValues[0] = GenerateXmlFromProperty(typeof(Type), "Type", value ?? string.Empty);
            value = (e).NodeType;
            XElementValues[1] = GenerateXmlFromProperty(typeof(ExpressionType), "NodeType", value ?? string.Empty);
            value = (e).Parameters;
            XElementValues[2] = GenerateXmlFromProperty(typeof(ReadOnlyCollection<ParameterExpression>), "Parameters", value ?? string.Empty);
            value = (e).Name;
            XElementValues[3] = GenerateXmlFromProperty(typeof(String), "Name", value ?? string.Empty);
            value = (e).Body;
            XElementValues[4] = GenerateXmlFromProperty(typeof(Expression), "Body", value ?? string.Empty);
            value = (e).ReturnType;
            XElementValues[5] = GenerateXmlFromProperty(typeof(Type), "ReturnType", value ?? string.Empty);
            value = (e).TailCall;
            XElementValues[6] = GenerateXmlFromProperty(typeof(Boolean), "TailCall", value ?? string.Empty);
            value = (e).CanReduce;
            XElementValues[7] = GenerateXmlFromProperty(typeof(Boolean), "CanReduce", value ?? string.Empty);
            return new XElement(xName, XElementValues);
        }

        //end static method
        internal XElement ListInitExpressionToXElement(ListInitExpression e)
        {
            object value;
            string xName = "ListInitExpression";
            var XElementValues = new object[5];
            value = (e).NodeType;
            XElementValues[0] = GenerateXmlFromProperty(typeof(ExpressionType), "NodeType", value ?? string.Empty);
            value = (e).Type;
            XElementValues[1] = GenerateXmlFromProperty(typeof(Type), "Type", value ?? string.Empty);
            value = (e).CanReduce;
            XElementValues[2] = GenerateXmlFromProperty(typeof(Boolean), "CanReduce", value ?? string.Empty);
            value = (e).NewExpression;
            XElementValues[3] = GenerateXmlFromProperty(typeof(NewExpression), "NewExpression", value ?? string.Empty);
            value = (e).Initializers;
            XElementValues[4] = GenerateXmlFromProperty(typeof(ReadOnlyCollection<ElementInit>), "Initializers", value ?? string.Empty);
            return new XElement(xName, XElementValues);
        }

        //end static method
        internal XElement LoopExpressionToXElement(LoopExpression e)
        {
            object value;
            string xName = "LoopExpression";
            var XElementValues = new object[6];
            value = (e).Type;
            XElementValues[0] = GenerateXmlFromProperty(typeof(Type), "Type", value ?? string.Empty);
            value = (e).NodeType;
            XElementValues[1] = GenerateXmlFromProperty(typeof(ExpressionType), "NodeType", value ?? string.Empty);
            value = (e).Body;
            XElementValues[2] = GenerateXmlFromProperty(typeof(Expression), "Body", value ?? string.Empty);
            value = (e).BreakLabel;
            XElementValues[3] = GenerateXmlFromProperty(typeof(LabelTarget), "BreakLabel", value ?? string.Empty);
            value = (e).ContinueLabel;
            XElementValues[4] = GenerateXmlFromProperty(typeof(LabelTarget), "ContinueLabel", value ?? string.Empty);
            value = (e).CanReduce;
            XElementValues[5] = GenerateXmlFromProperty(typeof(Boolean), "CanReduce", value ?? string.Empty);
            return new XElement(xName, XElementValues);
        }

        //end static method
        internal XElement MemberExpressionToXElement(MemberExpression e)
        {
            object value;
            string xName = "MemberExpression";
            var XElementValues = new object[5];
            value = (e).Member;
            XElementValues[0] = GenerateXmlFromProperty(typeof(MemberInfo), "Member", value ?? string.Empty);
            value = (e).Expression;
            XElementValues[1] = GenerateXmlFromProperty(typeof(Expression), "Expression", value ?? string.Empty);
            value = (e).NodeType;
            XElementValues[2] = GenerateXmlFromProperty(typeof(ExpressionType), "NodeType", value ?? string.Empty);
            value = (e).Type;
            XElementValues[3] = GenerateXmlFromProperty(typeof(Type), "Type", value ?? string.Empty);
            value = (e).CanReduce;
            XElementValues[4] = GenerateXmlFromProperty(typeof(Boolean), "CanReduce", value ?? string.Empty);
            return new XElement(xName, XElementValues);
        }

        //end static method
        internal XElement MemberInitExpressionToXElement(MemberInitExpression e)
        {
            object value;
            string xName = "MemberInitExpression";
            var XElementValues = new object[5];
            value = (e).Type;
            XElementValues[0] = GenerateXmlFromProperty(typeof(Type), "Type", value ?? string.Empty);
            value = (e).CanReduce;
            XElementValues[1] = GenerateXmlFromProperty(typeof(Boolean), "CanReduce", value ?? string.Empty);
            value = (e).NodeType;
            XElementValues[2] = GenerateXmlFromProperty(typeof(ExpressionType), "NodeType", value ?? string.Empty);
            value = (e).NewExpression;
            XElementValues[3] = GenerateXmlFromProperty(typeof(NewExpression), "NewExpression", value ?? string.Empty);
            value = (e).Bindings;
            XElementValues[4] = GenerateXmlFromProperty(typeof(ReadOnlyCollection<MemberBinding>), "Bindings", value ?? string.Empty);
            return new XElement(xName, XElementValues);
        }

        //end static method
        internal XElement MethodCallExpressionToXElement(MethodCallExpression e)
        {
            object value;
            string xName = "MethodCallExpression";
            var XElementValues = new object[6];
            value = (e).NodeType;
            XElementValues[0] = GenerateXmlFromProperty(typeof(ExpressionType), "NodeType", value ?? string.Empty);
            value = (e).Type;
            XElementValues[1] = GenerateXmlFromProperty(typeof(Type), "Type", value ?? string.Empty);
            value = (e).Method;
            XElementValues[2] = GenerateXmlFromProperty(typeof(MethodInfo), "Method", value ?? string.Empty);
            value = (e).Object;
            XElementValues[3] = GenerateXmlFromProperty(typeof(Expression), "Object", value ?? string.Empty);
            value = (e).Arguments;
            XElementValues[4] = GenerateXmlFromProperty(typeof(ReadOnlyCollection<Expression>), "Arguments", value ?? string.Empty);
            value = (e).CanReduce;
            XElementValues[5] = GenerateXmlFromProperty(typeof(Boolean), "CanReduce", value ?? string.Empty);
            return new XElement(xName, XElementValues);
        }

        //end static method
        internal XElement NewArrayExpressionToXElement(NewArrayExpression e)
        {
            object value;
            string xName = "NewArrayExpression";
            var XElementValues = new object[4];
            value = (e).Type;
            XElementValues[0] = GenerateXmlFromProperty(typeof(Type), "Type", value ?? string.Empty);
            value = (e).Expressions;
            XElementValues[1] = GenerateXmlFromProperty(typeof(ReadOnlyCollection<Expression>), "Expressions", value ?? string.Empty);
            value = (e).NodeType;
            XElementValues[2] = GenerateXmlFromProperty(typeof(ExpressionType), "NodeType", value ?? string.Empty);
            value = (e).CanReduce;
            XElementValues[3] = GenerateXmlFromProperty(typeof(Boolean), "CanReduce", value ?? string.Empty);
            return new XElement(xName, XElementValues);
        }

        //end static method
        internal XElement NewExpressionToXElement(NewExpression e)
        {
            object value;
            string xName = "NewExpression";
            var XElementValues = new object[6];
            value = (e).Type;
            XElementValues[0] = GenerateXmlFromProperty(typeof(Type), "Type", value ?? string.Empty);
            value = (e).NodeType;
            XElementValues[1] = GenerateXmlFromProperty(typeof(ExpressionType), "NodeType", value ?? string.Empty);
            value = (e).Constructor;
            XElementValues[2] = GenerateXmlFromProperty(typeof(ConstructorInfo), "Constructor", value ?? string.Empty);
            value = (e).Arguments;
            XElementValues[3] = GenerateXmlFromProperty(typeof(ReadOnlyCollection<Expression>), "Arguments", value ?? string.Empty);
            value = (e).Members;
            XElementValues[4] = GenerateXmlFromProperty(typeof(ReadOnlyCollection<MemberInfo>), "Members", value ?? string.Empty);
            value = (e).CanReduce;
            XElementValues[5] = GenerateXmlFromProperty(typeof(Boolean), "CanReduce", value ?? string.Empty);
            return new XElement(xName, XElementValues);
        }

        //end static method
        internal XElement ParameterExpressionToXElement(ParameterExpression e)
        {
            object value;
            string xName = "ParameterExpression";
            var XElementValues = new object[5];
            value = (e).Type;
            XElementValues[0] = GenerateXmlFromProperty(typeof(Type), "Type", value ?? string.Empty);
            value = (e).NodeType;
            XElementValues[1] = GenerateXmlFromProperty(typeof(ExpressionType), "NodeType", value ?? string.Empty);
            value = (e).Name;
            XElementValues[2] = GenerateXmlFromProperty(typeof(String), "Name", value ?? string.Empty);
            value = (e).IsByRef;
            XElementValues[3] = GenerateXmlFromProperty(typeof(Boolean), "IsByRef", value ?? string.Empty);
            value = (e).CanReduce;
            XElementValues[4] = GenerateXmlFromProperty(typeof(Boolean), "CanReduce", value ?? string.Empty);
            return new XElement(xName, XElementValues);
        }

        //end static method
        internal XElement RuntimeVariablesExpressionToXElement(RuntimeVariablesExpression e)
        {
            object value;
            string xName = "RuntimeVariablesExpression";
            var XElementValues = new object[4];
            value = (e).Type;
            XElementValues[0] = GenerateXmlFromProperty(typeof(Type), "Type", value ?? string.Empty);
            value = (e).NodeType;
            XElementValues[1] = GenerateXmlFromProperty(typeof(ExpressionType), "NodeType", value ?? string.Empty);
            value = (e).Variables;
            XElementValues[2] = GenerateXmlFromProperty(typeof(ReadOnlyCollection<ParameterExpression>), "Variables", value ?? string.Empty);
            value = (e).CanReduce;
            XElementValues[3] = GenerateXmlFromProperty(typeof(Boolean), "CanReduce", value ?? string.Empty);
            return new XElement(xName, XElementValues);
        }

        //end static method
        internal XElement SwitchExpressionToXElement(SwitchExpression e)
        {
            object value;
            string xName = "SwitchExpression";
            var XElementValues = new object[7];
            value = (e).Type;
            XElementValues[0] = GenerateXmlFromProperty(typeof(Type), "Type", value ?? string.Empty);
            value = (e).NodeType;
            XElementValues[1] = GenerateXmlFromProperty(typeof(ExpressionType), "NodeType", value ?? string.Empty);
            value = (e).SwitchValue;
            XElementValues[2] = GenerateXmlFromProperty(typeof(Expression), "SwitchValue", value ?? string.Empty);
            value = (e).Cases;
            XElementValues[3] = GenerateXmlFromProperty(typeof(ReadOnlyCollection<SwitchCase>), "Cases", value ?? string.Empty);
            value = (e).DefaultBody;
            XElementValues[4] = GenerateXmlFromProperty(typeof(Expression), "DefaultBody", value ?? string.Empty);
            value = (e).Comparison;
            XElementValues[5] = GenerateXmlFromProperty(typeof(MethodInfo), "Comparison", value ?? string.Empty);
            value = (e).CanReduce;
            XElementValues[6] = GenerateXmlFromProperty(typeof(Boolean), "CanReduce", value ?? string.Empty);
            return new XElement(xName, XElementValues);
        }

        //end static method
        internal XElement TryExpressionToXElement(TryExpression e)
        {
            object value;
            string xName = "TryExpression";
            var XElementValues = new object[7];
            value = (e).Type;
            XElementValues[0] = GenerateXmlFromProperty(typeof(Type), "Type", value ?? string.Empty);
            value = (e).NodeType;
            XElementValues[1] = GenerateXmlFromProperty(typeof(ExpressionType), "NodeType", value ?? string.Empty);
            value = (e).Body;
            XElementValues[2] = GenerateXmlFromProperty(typeof(Expression), "Body", value ?? string.Empty);
            value = (e).Handlers;
            XElementValues[3] = GenerateXmlFromProperty(typeof(ReadOnlyCollection<CatchBlock>), "Handlers", value ?? string.Empty);
            value = (e).Finally;
            XElementValues[4] = GenerateXmlFromProperty(typeof(Expression), "Finally", value ?? string.Empty);
            value = (e).Fault;
            XElementValues[5] = GenerateXmlFromProperty(typeof(Expression), "Fault", value ?? string.Empty);
            value = (e).CanReduce;
            XElementValues[6] = GenerateXmlFromProperty(typeof(Boolean), "CanReduce", value ?? string.Empty);
            return new XElement(xName, XElementValues);
        }

        //end static method
        internal XElement TypeBinaryExpressionToXElement(TypeBinaryExpression e)
        {
            object value;
            string xName = "TypeBinaryExpression";
            var XElementValues = new object[5];
            value = (e).Type;
            XElementValues[0] = GenerateXmlFromProperty(typeof(Type), "Type", value ?? string.Empty);
            value = (e).NodeType;
            XElementValues[1] = GenerateXmlFromProperty(typeof(ExpressionType), "NodeType", value ?? string.Empty);
            value = (e).Expression;
            XElementValues[2] = GenerateXmlFromProperty(typeof(Expression), "Expression", value ?? string.Empty);
            value = (e).TypeOperand;
            XElementValues[3] = GenerateXmlFromProperty(typeof(Type), "TypeOperand", value ?? string.Empty);
            value = (e).CanReduce;
            XElementValues[4] = GenerateXmlFromProperty(typeof(Boolean), "CanReduce", value ?? string.Empty);
            return new XElement(xName, XElementValues);
        }

        //end static method
        internal XElement UnaryExpressionToXElement(UnaryExpression e)
        {
            object value;
            string xName = "UnaryExpression";
            var XElementValues = new object[7];
            value = (e).Type;
            XElementValues[0] = GenerateXmlFromProperty(typeof(Type), "Type", value ?? string.Empty);
            value = (e).NodeType;
            XElementValues[1] = GenerateXmlFromProperty(typeof(ExpressionType), "NodeType", value ?? string.Empty);
            value = (e).Operand;
            XElementValues[2] = GenerateXmlFromProperty(typeof(Expression), "Operand", value ?? string.Empty);
            value = (e).Method;
            XElementValues[3] = GenerateXmlFromProperty(typeof(MethodInfo), "Method", value ?? string.Empty);
            value = (e).IsLifted;
            XElementValues[4] = GenerateXmlFromProperty(typeof(Boolean), "IsLifted", value ?? string.Empty);
            value = (e).IsLiftedToNull;
            XElementValues[5] = GenerateXmlFromProperty(typeof(Boolean), "IsLiftedToNull", value ?? string.Empty);
            value = (e).CanReduce;
            XElementValues[6] = GenerateXmlFromProperty(typeof(Boolean), "CanReduce", value ?? string.Empty);
            return new XElement(xName, XElementValues);
        }

        //end static method
    }


    //end ExpressionSerializer class
}